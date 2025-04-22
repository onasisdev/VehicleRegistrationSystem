namespace Entities
{
    public class OwnersManagement : OwnersManagementBase
    {
        public override Dictionary<int, string> OwnerFullNames { get; set; }
        public override Dictionary<int, string> OwnerSocialIds { get; set; }
        public override Dictionary<int, string> OwnerAddresses { get; set; }
        public override Dictionary<int, string> OwnerPhoneNumbers { get; set; }
        public override Dictionary<int, string> OwnerEmails { get; set; }
        public override List<int> OwnerIds { get; set; }

        public OwnersManagement(Dictionary<int, string> ownerFullNames, Dictionary<int, string> ownerSocialIds, Dictionary<int, string> ownerAddresses, Dictionary<int, string> ownerPhoneNumbers, Dictionary<int, string> ownerEmails, List<int> ownerIds)
        {
            this.OwnerFullNames = ownerFullNames;
            this.OwnerSocialIds = ownerSocialIds;
            this.OwnerAddresses = ownerAddresses;
            this.OwnerPhoneNumbers = ownerPhoneNumbers;
            this.OwnerEmails = ownerEmails;
            this.OwnerIds = ownerIds;

        }

        public override void ViewAllOwners()
        {
            Console.WriteLine("");

            Console.WriteLine("Propietarios: ");

            foreach (var ownerId in OwnerIds)
            {
                Console.WriteLine($"""
                    id: {ownerId}   Nombre completo: {OwnerFullNames[ownerId]}   Cédula: {OwnerSocialIds[ownerId]}   Dirección: {OwnerAddresses[ownerId]}   Teléfono: {OwnerPhoneNumbers[ownerId]}   Correo electrónico: {OwnerEmails[ownerId]}
                    """);
            }

            Console.WriteLine("");
        }
    }
}


