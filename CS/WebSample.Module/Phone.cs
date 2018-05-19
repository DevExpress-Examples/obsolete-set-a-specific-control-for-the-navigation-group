using DevExpress.Xpo;

using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace WebSample.Module {
    [NavigationItem("Data")]
    public class Phone : BaseObject {
        public Phone(Session session) : base(session) { }

        private string _Comments;
        public string Comments {
            get { return _Comments; }
            set { SetPropertyValue("Comments", ref _Comments, value); }
        }
        private int _Number;
        public int Number {
            get { return _Number; }
            set { SetPropertyValue("Number", ref _Number, value); }
        }
        private Contact _Contact;
        [Association("Contact-Phones")]
        public Contact Contact {
            get { return _Contact; }
            set { SetPropertyValue("Contact", ref _Contact, value); }
        }
    }
}
