using Newtonsoft.Json;

namespace ScriptCs.ObjectDumper.ScriptPack
{
  public class ObjectSerializer
  {
    private readonly bool _objectReferences;
    private readonly bool _indent;
    private readonly bool _includeNulls = true;

    private readonly JsonSerializerSettings _settings;

    public ObjectSerializer(bool objectReferences, bool indent, bool includeNulls)
    {
      _objectReferences = objectReferences;
      _indent = indent;
      _includeNulls = includeNulls;
      _settings = InitialiseSerializerSettings();
    }

    private JsonSerializerSettings InitialiseSerializerSettings()
    {
      return new JsonSerializerSettings
      {
        PreserveReferencesHandling = (_objectReferences) ? PreserveReferencesHandling.Objects : PreserveReferencesHandling.None,
        ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
        NullValueHandling = (_includeNulls) ? NullValueHandling.Include : NullValueHandling.Ignore,
        MaxDepth = 4
      };
    }

    public string Serialize(object value)
    {
      return JsonConvert.SerializeObject(value, (_indent) ? Formatting.Indented : Formatting.None, _settings);
    }
  }
}
