using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.VisualStudio.DebuggerVisualizers;

using TestDomain;

[assembly: DebuggerVisualizer(typeof(Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(List<double>),
    Description = "List<double> visualizer")]

[assembly: DebuggerVisualizer(typeof(Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(IList<double>),
    Description = "IList<double> visualizer")]

[assembly: DebuggerVisualizer(typeof(Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(IList<>),
    Description = "IList<> visualizer")]

[assembly: DebuggerVisualizer(typeof(Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(List<>),
    Description = "List<> visualizer")]

[assembly: DebuggerVisualizer(typeof(Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(IEnumerable<double>),
    Description = "IEnumerable<double> visualizer")]

[assembly: DebuggerVisualizer(typeof(Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(IEnumerable<>),
    Description = "IEnumerable<> visualizer")]

[assembly: DebuggerVisualizer(typeof(Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(ICollection<>),
    Description = "ICollection<> visualizer")]

[assembly: DebuggerVisualizer(typeof(Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(ICollection<double>),
    Description = "ICollection<double> visualizer")]

[assembly: DebuggerVisualizer(typeof(Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(IReadOnlyList<>),
    Description = "IReadOnlyList<> visualizer")]

[assembly: DebuggerVisualizer(typeof(Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(IReadOnlyList<double>),
    Description = "IReadOnlyList<double> visualizer")]

[assembly: DebuggerVisualizer(typeof(Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(IReadOnlyCollection<>),
    Description = "IReadOnlyCollection<> visualizer")]

[assembly: DebuggerVisualizer(typeof(Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(IReadOnlyCollection<double>),
    Description = "IReadOnlyCollection<double> visualizer")]

[assembly: DebuggerVisualizer(typeof(Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(ICollection),
    Description = "ICollection visualizer")]

[assembly: DebuggerVisualizer(typeof(Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(MyGenericObject<double>),
    Description = "MyGenericObject<double> visualizer")]

[assembly: DebuggerVisualizer(typeof(Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(MyGenericObject<>),
    Description = "MyGenericObject<> visualizer")]

[assembly: DebuggerVisualizer(typeof(Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(MyObject),
    Description = "MyObject visualizer")]

[assembly: DebuggerVisualizer(typeof(Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(MyInterface),
    Description = "MyInterface visualizer")]

[assembly: DebuggerVisualizer(typeof(Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(MyGenericInterface<>),
    Description = "MyGenericInterface<> visualizer")]

[assembly: DebuggerVisualizer(typeof(Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(MyGenericInterface<double>),
    Description = "MyGenericInterface<double> visualizer")]

// When this attribute is defined, not a single visualizer is offered.
// Uncomment, rebuild and start with debugger attached to test.
//[assembly: DebuggerVisualizer(typeof(Visualizer),
//    typeof(VisualizerObjectSource),
//    Target = typeof(SortedList<int, string>),
//    Description = "SortedList<int, string> visualizer")]