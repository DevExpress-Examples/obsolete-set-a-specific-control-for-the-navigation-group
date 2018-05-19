using DevExpress.Xpo;

using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace WebSample.Module {
    [NavigationItem("Data")]
    public class ContactAddress : DevExpress.Persistent.BaseImpl.Address {
        public ContactAddress(Session session) : base(session) { }
        private Contact _Contact;
        [Association("Contact-Addresses")]
        public Contact Contact {
            get { return _Contact; }
            set { SetPropertyValue("Contact", ref _Contact, value); }
        }       
    }
}
