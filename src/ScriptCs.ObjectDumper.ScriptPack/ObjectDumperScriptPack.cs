using ScriptCs.Contracts;

namespace ScriptCs.ObjectDumper.ScriptPack
{
  public class ObjectDumperScriptPack : IScriptPack
  {
    public IScriptPackContext GetContext()
    {
      return new ObjectDumper();
    }

    public void Initialize(IScriptPackSession session) { }
    public void Terminate() { }
  }
}
