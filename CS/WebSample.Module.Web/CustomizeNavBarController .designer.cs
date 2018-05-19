using DevExpress.ExpressApp;
namespace WebSample.Module.Web {
    partial class NavBarViewChangingController {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem1 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem2 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem3 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            this.singleChoiceAction1 = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // singleChoiceAction1
            // 
            this.singleChoiceAction1.Caption = "MyAction";
            this.singleChoiceAction1.Category = "MyMenu";
            this.singleChoiceAction1.Id = "01551fd6-1b4f-449d-bf8c-71172a297f59";
            choiceActionItem1.Caption = "Contact";
            choiceActionItem1.Data = "Contact";
            choiceActionItem1.ImageName = "BO_Person";
            choiceActionItem2.Caption = "Address";
            choiceActionItem2.Data = "ContactAddress";
            choiceActionItem2.ImageName = "BO_Address";
            choiceActionItem1.Items.Add(choiceActionItem2);
            choiceActionItem3.Caption = "Phone";
            choiceActionItem3.Data = "Phone";
            choiceActionItem3.ImageName = "BO_Note";
            choiceActionItem1.Items.Add(choiceActionItem3);
            this.singleChoiceAction1.Items.Add(choiceActionItem1);
            this.singleChoiceAction1.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(singleChoiceAction1_Execute);

        }
        #endregion
        private DevExpress.ExpressApp.Actions.SingleChoiceAction singleChoiceAction1;
    }
}
