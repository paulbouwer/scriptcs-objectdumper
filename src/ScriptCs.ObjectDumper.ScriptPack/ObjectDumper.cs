using ScriptCs.Contracts;

namespace ScriptCs.ObjectDumper.ScriptPack
{
  public partial class ObjectDumper : IScriptPackContext
  {
    private ObjectSerializer _objectSerializer;

    public string Dump(object o)
    {
      return _objectSerializer.Serialize(o);
    }
  }
}
