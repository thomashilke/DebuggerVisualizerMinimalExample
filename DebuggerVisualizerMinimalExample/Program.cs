using System;
using System.Collections.Generic;

using TestDomain;

var list = new List<double> { 1.0, 2.0, 3.0 };
var myGenericObject = new MyGenericObject<double>();
var myObject = new MyObject();

var myInterface = (MyInterface)new MyInterfaceImplementation();
var myGenericInterface = (MyGenericInterface<double>)new MyGenericInterfaceImplementation<double>();

Console.WriteLine("Set a breakpoint on this line.");
