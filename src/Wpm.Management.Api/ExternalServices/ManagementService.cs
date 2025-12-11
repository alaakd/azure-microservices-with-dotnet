
namespace Wpm.Management.Api.ExternalServices
{
    public class ManagementService(HttpClient client)
    {
        public async Task<PetInfo> GetPetInfoAsync(int id)
        {
            var petInfo = await client.GetFromJsonAsync<PetInfo>($"/api/pets/{id}");
            return petInfo;
        }
    }
}

public record PetInfo(int Id, string Name, int Age, int BreedId)
{
    //public static implicit operator PetInfo?(Wpm.Clinic.ExternalServices.PetInfo? v)
    //{
    //    throw new NotImplementedException();
    //}
}
