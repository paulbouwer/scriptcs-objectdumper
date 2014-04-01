namespace ScriptCs.ObjectDumper.ScriptPack
{
  public class ObjectSerializerBuilder
  {
    private bool _objectReferences = false;
    private bool _indent = true;
    private bool _includeNulls = true;

    public void IncludeObjectReferences()
    {
      _objectReferences = true;
    }

    public void ExcludeObjectReferences()
    {
      _objectReferences = false;
    }

    public void PrettyPrint()
    {
      _indent = true;
    }

    public void Compact()
    {
      _indent = false;
    }

    public void IncludeNullValues()
    {
      _includeNulls = true;
    }

    public void ExcludeNullValues()
    {
      _includeNulls = false;
    }

    public ObjectSerializer Build()
    {
      return new ObjectSerializer(_objectReferences, _indent, _includeNulls);
    }
  }
}
