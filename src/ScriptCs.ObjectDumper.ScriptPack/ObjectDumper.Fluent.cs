namespace ScriptCs.ObjectDumper.ScriptPack
{
  public partial class ObjectDumper : IFluentConfiguration
  {
    private readonly ObjectSerializerBuilder _objectSerializerBuilder = new ObjectSerializerBuilder();

    public IFluentConfiguration IncludeObjectReferences()
    {
      _objectSerializerBuilder.IncludeObjectReferences();
      return this;
    }

    public IFluentConfiguration ExcludeObjectReferences()
    {
      _objectSerializerBuilder.ExcludeObjectReferences();
      return this;
    }

    public IFluentConfiguration PrettyPrint()
    {
      _objectSerializerBuilder.PrettyPrint();
      return this;
    }

    public IFluentConfiguration Compact()
    {
      _objectSerializerBuilder.Compact();
      return this;
    }

    public IFluentConfiguration IncludeNullValues()
    {
      _objectSerializerBuilder.IncludeNullValues();
      return this;
    }

    public IFluentConfiguration ExcludeNullValues()
    {
      _objectSerializerBuilder.ExcludeNullValues();
      return this;
    }

    public ObjectDumper Build()
    {
      _objectSerializer = _objectSerializerBuilder.Build();
      return this;
    }
  }
}
