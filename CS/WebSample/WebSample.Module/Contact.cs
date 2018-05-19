using DevExpress.Xpo;

using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace WebSample.Module {
    [NavigationItem("Data")]
    public class Contact : BaseObject {
        public Contact(Session session) : base(session) { }

        private string _Name;
        public string Name {
            get { return _Name; }
            set { SetPropertyValue("Name", ref _Name, value); }
        }
        private string _Email;
        public string Email {
            get { return _Email; }
            set { SetPropertyValue("Email", ref _Email, value); }
        }
        [Association("Contact-Phones"), Aggregated]
        public XPCollection<Phone> Phones {
            get { return GetCollection<Phone>("Phones"); }
        }
        [Association("Contact-Addresses")]
        public XPCollection<ContactAddress> Addresses {
            get { return GetCollection<ContactAddress>("Addresses"); }
        }
    }
}
