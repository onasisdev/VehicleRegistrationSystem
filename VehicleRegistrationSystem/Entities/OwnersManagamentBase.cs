namespace Entities
{
    public abstract class OwnersManagementBase
    {
        public virtual Dictionary<int, string> OwnerFullNames { get; set; }
        public virtual Dictionary<int, string> OwnerSocialIds { get; set; }
        public virtual Dictionary<int, string> OwnerAddresses { get; set; }
        public virtual Dictionary<int, string> OwnerPhoneNumbers { get; set; }
        public virtual Dictionary<int, string> OwnerEmails { get; set; }
        public virtual List<int> OwnerIds { get; set;}


        public abstract void ViewAllOwners();
    }
}


