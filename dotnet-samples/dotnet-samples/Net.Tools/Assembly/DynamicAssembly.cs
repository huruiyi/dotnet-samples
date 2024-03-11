using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace Net.Tools.Assembly
{
    internal class DynamicAssembly
    {
        private static void CreateStudentDynamicAssembly()
        {
            //返回当前执行进程的当前应用域
            AppDomain myDomain = Thread.GetDomain();

            //完整描述程序集的唯一标识
            AssemblyName myAssemblyName = new AssemblyName
            {
                Name = "CreatingDynamicAssembliesDemo"
            };

            //以指定名称和访问模式定义动态程序集
            AssemblyBuilder myAssemblyBuilder = myDomain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.RunAndSave);

            ModuleBuilder stuModule = CreateModule(myAssemblyBuilder, myAssemblyName);
            TypeBuilder stuTypeBuilder = CreateStudentTypeBuilder(stuModule);
            CreateEnumForStudentType(stuModule);
            CreateSayHelloMethod(stuTypeBuilder);
            CreateFullNameField(stuTypeBuilder);
            CrateFullNameProperty(stuTypeBuilder);

            stuTypeBuilder.CreateType();
            myAssemblyBuilder.Save(myAssemblyName.Name + ".dll");
        }

        public static ModuleBuilder CreateModule(AssemblyBuilder stuAssemblyBuilder, AssemblyName stuAssemblyName)
        {
            ModuleBuilder myModuleBuilder = stuAssemblyBuilder.DefineDynamicModule(stuAssemblyName.Name + ".dll");
            return myModuleBuilder;
        }

        /// <summary>
        /// 创建枚举类型
        /// </summary>
        /// <param name="yourModuleBuilder"></param>
        public static void CreateEnumForStudentType(ModuleBuilder yourModuleBuilder)
        {
            EnumBuilder myEnumBuilder = yourModuleBuilder.DefineEnum("DynamicDemo.StudentType", TypeAttributes.Public, typeof(Int32));
            FieldBuilder gradField = myEnumBuilder.DefineLiteral("Graduate", 2);
            myEnumBuilder.CreateType();
        }

        /// <summary>
        /// 在给定类型名称和类型属性的情况下，构造 TypeBuilder
        /// </summary>
        /// <param name="stuModuleBuilder"></param>
        /// <returns></returns>
        public static TypeBuilder CreateStudentTypeBuilder(ModuleBuilder stuModuleBuilder)
        {
            TypeBuilder myTypeBuilder = stuModuleBuilder.DefineType("Student", TypeAttributes.Public);
            return myTypeBuilder;
        }

        /// <summary>
        /// 创建构造函数
        /// </summary>
        /// <param name="yourTypeBuilder"></param>
        public static void CreateStudentConstructorBuilder(TypeBuilder yourTypeBuilder)
        {
            ConstructorBuilder myConstructorBuilder = yourTypeBuilder.DefineConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName, CallingConventions.Standard, Type.EmptyTypes);
        }

        /// <summary>
        /// 创建方法
        /// </summary>
        /// <param name="youTypeBuilder"></param>
        public static void CreateSayHelloMethod(TypeBuilder youTypeBuilder)
        {
            MethodBuilder method = youTypeBuilder.DefineMethod("SyaHello", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName, null, Type.EmptyTypes);

            //CreateMessageParameter(method);
            //CreateGenericParameter(method);
            method.GetILGenerator().Emit(OpCodes.Ret);
        }

        /// <summary>
        /// 创建字段
        /// </summary>
        /// <param name="stuTypeBuilder"></param>
        public static void CreateFullNameField(TypeBuilder stuTypeBuilder)
        {
            FieldBuilder myFieldBuilder = stuTypeBuilder.DefineField("FullName", typeof(string), FieldAttributes.Private);
        }

        /// <summary>
        /// 创建FullName读取属性
        /// </summary>
        /// <param name="stuTypeBuilder"></param>
        public static void CrateFullNameProperty(TypeBuilder stuTypeBuilder)
        {
            PropertyBuilder stuFullNamePropBuilder = stuTypeBuilder.DefineProperty("FullName", PropertyAttributes.None, typeof(string), null);
            const MethodAttributes getSetAttr = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;

            MethodBuilder stuFullNameGetPropMethodBuilder = stuTypeBuilder.DefineMethod("get_FullName", getSetAttr, typeof(string), Type.EmptyTypes);
            ILGenerator custNameGetIl = stuFullNameGetPropMethodBuilder.GetILGenerator();
            custNameGetIl.Emit(OpCodes.Ldarg_0);
            custNameGetIl.Emit(OpCodes.Ldfld);
            custNameGetIl.Emit(OpCodes.Ldfld, stuFullNameGetPropMethodBuilder);
            custNameGetIl.Emit(OpCodes.Ret);

            MethodBuilder stuFullNameSetPropMethodBuilder = stuTypeBuilder.DefineMethod("set_FullName", getSetAttr, null, new Type[] { typeof(string) });
            ILGenerator custNameSetIl = stuFullNameSetPropMethodBuilder.GetILGenerator();
            custNameSetIl.Emit(OpCodes.Ldarg_0);
            custNameSetIl.Emit(OpCodes.Ldarg_1);
            custNameSetIl.Emit(OpCodes.Stfld, stuFullNameSetPropMethodBuilder);
            custNameSetIl.Emit(OpCodes.Ret);

            stuFullNamePropBuilder.SetGetMethod(stuFullNameGetPropMethodBuilder);
            stuFullNamePropBuilder.SetGetMethod(stuFullNameSetPropMethodBuilder);
        }

        public static void CreateMessageParameter(MethodBuilder yourMethodBuilder)
        {
            ParameterBuilder yourMessage = yourMethodBuilder.DefineParameter(1, ParameterAttributes.In, "yourMessage");
        }

        public static void CreateGenericParameter(MethodBuilder yourMethodBuilder)
        {
            string[] typeParamNames = { "Two", "TTwo" };
            GenericTypeParameterBuilder[] typeParams = yourMethodBuilder.DefineGenericParameters(typeParamNames);
        }

        public void CreateLocalVariables(MethodBuilder sayHelloMethod)
        {
            ILGenerator myMethodIl = sayHelloMethod.GetILGenerator();

            LocalBuilder localStringVariable = myMethodIl.DeclareLocal(typeof(string));
            localStringVariable.SetLocalSymInfo("myString");

            LocalBuilder localIntVariable = myMethodIl.DeclareLocal(typeof(int));
            localIntVariable.SetLocalSymInfo("myInt", 1, 2);

            myMethodIl.Emit(OpCodes.Ldstr, "Local value");
            myMethodIl.Emit(OpCodes.Stloc_0);
            myMethodIl.Emit(OpCodes.Ldloc_0);
            myMethodIl.Emit(OpCodes.Stloc_1);
            myMethodIl.Emit(OpCodes.Ldloc_1);
            myMethodIl.Emit(OpCodes.Ret);
        }
    }
}