using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Domain.Entitites
{
    public class LegalPerson : Collaborator
    {
        public string BusinessName { get; set; }
        public string Category { get; set; }
        public string  OrganizationType  { get; set; }

        public FridgeOwner DonateFridge(int fridgeId)=>
         new FridgeOwner()
            {
                FridgeId = fridgeId,
                CollaboratorId = this.Id
            };

    }
}
