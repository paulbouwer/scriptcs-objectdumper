namespace ScriptCs.ObjectDumper.ScriptPack
{
  public interface IFluentConfiguration
  {
    IFluentConfiguration IncludeObjectReferences();
    IFluentConfiguration ExcludeObjectReferences();
    IFluentConfiguration PrettyPrint();
    IFluentConfiguration Compact();
    IFluentConfiguration IncludeNullValues();
    IFluentConfiguration ExcludeNullValues();
    ObjectDumper Build();
  }
}
