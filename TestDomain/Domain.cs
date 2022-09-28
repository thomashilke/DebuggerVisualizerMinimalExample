namespace TestDomain
{
    public class MyGenericObject<T>
    { }

    public class MyObject
    { }

    public interface MyGenericInterface<T>
    { }

    public interface MyInterface
    { }

    public class MyGenericInterfaceImplementation<T> : MyGenericInterface<T>
    { }

    public class MyInterfaceImplementation: MyInterface
    { }
}