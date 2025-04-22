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

        public OwnersManagement()
        {
            this.OwnerFullNames = new Dictionary<int, string>();
            this.OwnerSocialIds = new Dictionary<int, string>();
            this.OwnerAddresses = new Dictionary<int, string>();
            this.OwnerPhoneNumbers = new Dictionary<int, string>();
            this.OwnerEmails = new Dictionary<int, string>();
            this.OwnerIds = new List<int>();

        }

        
    }
}


