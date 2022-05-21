using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace Zu1779.GenUtil.Extension.ObjectExtension
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Check if parameter is null or default. <see cref="https://stackoverflow.com/questions/6553183/check-to-see-if-a-given-object-reference-or-value-type-is-equal-to-its-default"/>
        /// </summary>
        /// <remarks>Modified for consider <code>string.Empty</code> as default.</remarks>
        public static bool IsNullOrDefault<T>(this T argument)
        {
            if (argument is string && (argument as string) == string.Empty) return true;
            // deal with normal scenarios
            if (argument == null) return true;
            if (object.Equals(argument, default(T))) return true;

            // deal with non-null nullables
            Type methodType = typeof(T);
            if (Nullable.GetUnderlyingType(methodType) != null) return false;

            // deal with boxed value types
            Type argumentType = argument.GetType();
            if (argumentType.IsValueType && argumentType != methodType)
            {
                object obj = Activator.CreateInstance(argument.GetType());
                return obj.Equals(argument);
            }

            return false;
        }

        public static T As<T>(this object obj) => obj is T t ? t : default;

        public static IEnumerable<T> ToEnumerable<T>(this T obj) => new T[] { obj };
        public static IQueryable<T> ToQueryable<T>(this T obj) => obj.ToEnumerable().AsQueryable();

        public static void HandleEvent(object instance, EventInfo eInfo)
        {
            Type handlerType = eInfo.EventHandlerType;
            MethodInfo invokeMethod = handlerType.GetMethod("Invoke");
            ParameterInfo[] parms = invokeMethod.GetParameters();
            Type[] parmTypes = new Type[parms.Length];
            for (int i = 0; i < parms.Length; i++)
            {
                parmTypes[i] = parms[i].ParameterType;
            }

            // Use Reflection.Emit to create a dynamic assembly that
            // will be run but not saved. An assembly must have at
            // least one module, which in this case contains a single
            // type. The only purpose of this type is to contain the
            // event handler method. (You can use also dynamic methods,
            // which are simpler because there is no need to create an
            // assembly, module, or type.)
            //
            AssemblyName aName = new AssemblyName();
            aName.Name = "DynamicTypes";
            AssemblyBuilder ab = AssemblyBuilder.DefineDynamicAssembly(aName, AssemblyBuilderAccess.Run);
            ModuleBuilder mb = ab.DefineDynamicModule(aName.Name);
            TypeBuilder tb = mb.DefineType("Handler", TypeAttributes.Class | TypeAttributes.Public);

            // Create the method that will handle the event. The name
            // is not important. The method is static, because there is
            // no reason to create an instance of the dynamic type.
            //
            // The parameter types and return type of the method are
            // the same as those of the delegate's Invoke method,
            // captured earlier.
            MethodBuilder handler = tb.DefineMethod("DynamicHandler",
                MethodAttributes.Public | MethodAttributes.Static,
                invokeMethod.ReturnType, parmTypes);

            // Generate code to handle the event. In this case, the
            // handler simply prints a text string to the console.
            //
            ILGenerator il = handler.GetILGenerator();
            il.EmitWriteLine($"{eInfo.Name} RAISED");
            il.Emit(OpCodes.Ret);

            // CreateType must be called before the Handler type can
            // be used. In order to create the delegate that will
            // handle the event, a MethodInfo from the finished type
            // is required.
            Type finished = tb.CreateType();
            MethodInfo eventHandler = finished.GetMethod("DynamicHandler");

            // Use the MethodInfo to create a delegate of the correct
            // type, and call the AddEventHandler method to hook up
            // the event.
            Delegate d = Delegate.CreateDelegate(handlerType, eventHandler);
            eInfo.AddEventHandler(instance, d);
        }
    }
}
