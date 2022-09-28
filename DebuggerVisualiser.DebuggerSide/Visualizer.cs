using Microsoft.VisualStudio.DebuggerVisualizers;

public class Visualizer : DialogDebuggerVisualizer
{
    protected override void Show(IDialogVisualizerService service, IVisualizerObjectProvider provider) => 
        throw new System.Exception("Visualizer successfully called.");
}
