using System.Text.Json.Serialization;

namespace CRUD_Cliente.src.models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Sexo
    {
        MASCULINO,
        FEMININO
    }
}
