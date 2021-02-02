using System;
using System.Windows.Forms;
using System.Drawing;

namespace DecoratorFactoryExample
{
    public class GFrame : Form
    {
        private Label Title = new Label();
        private Label Alert = new Label();
        private Label CreditAmountLabel = new Label();
        private TextBox CreditAmountTextBox = new TextBox();
        private Label TransactionAmountLabel = new Label();
        private TextBox TransactionAmountBox = new TextBox();
        private Button Debit = new Button();
        private Button Payoff = new Button();
        private ComboBox Card = new ComboBox();
        private Button ChangeCard = new Button();
        private Button ResetCredit = new Button();
        private Button Exit = new Button();
        PictureBox CardIcon = new PictureBox();

        private Font f = new Font("Times New Roman", 14, FontStyle.Bold);

        CreditCard creditCard = Factory.CreateCreditCard("Visa");
        public GFrame() : base()
        {
            Title.Text = "Credit Card";
            Title.Font = f;
            Alert.Text = "";
            Debit.Text = "Debit";
            Payoff.Text = "Payoff";
            ChangeCard.Text = "Change Card";
            CreditAmountLabel.Text = "Credit Amount";
            CreditAmountTextBox.Enabled = false;
            TransactionAmountLabel.Text = "Transaction Amount";
            ResetCredit.Text = "Reset Credit";
            Exit.Text = "Exit";
            Card.Items.Add("Visa");
            Card.Items.Add("Master Card");
            Card.Items.Add("American Express");
            Card.Items.Add("Other");
            Card.Text = "Visa";
            CardIcon.ImageLocation = GetImage("Visa");
            CardIcon.SizeMode = PictureBoxSizeMode.AutoSize;

            RefreshForm();

            Title.SetBounds(30, 10, 220, 20);
            Alert.SetBounds(10, 50, 250, 40);
            CreditAmountLabel.SetBounds(10, 100, 100, 20);
            CreditAmountTextBox.SetBounds(110, 100, 100, 20);
            TransactionAmountLabel.SetBounds(10, 130, 100, 30);
            TransactionAmountBox.SetBounds(110, 130, 100, 20);
            Payoff.SetBounds(110, 170, 80, 20);
            Debit.SetBounds(10, 170, 80, 20);
            ChangeCard.SetBounds(10, 200, 80, 20);
            Card.SetBounds(110, 200, 80, 20);
            CardIcon.SetBounds(200, 200, 30, 30);
            ResetCredit.SetBounds(80, 230, 80, 20);
            Exit.SetBounds(80, 260, 80, 20);

            Debit.Click += new EventHandler(OnDebit);
            Payoff.Click += new EventHandler(OnPayoff);
            ResetCredit.Click += new EventHandler(OnResetCard);
            Exit.Click += new EventHandler(OnExit);
            ChangeCard.Click += new EventHandler(OnChangeCard);

            Controls.Add(Title);
            Controls.Add(Alert); 
            Controls.Add(CreditAmountLabel);
            Controls.Add(CreditAmountTextBox); 
            Controls.Add(TransactionAmountLabel);
            Controls.Add(TransactionAmountBox); 
            Controls.Add(ChangeCard);
            Controls.Add(Card); 
            Controls.Add(Debit);
            Controls.Add(Payoff);
            Controls.Add(ResetCredit);
            Controls.Add(Exit);
            Controls.Add(CardIcon);

            Height = 350;
            Width = 400;
        }

        private void RefreshForm()
        {
            CreditAmountTextBox.Text = "" + creditCard.ReadBalance();
            TransactionAmountBox.Text = "";
        }

        private void OnPayoff(object sender, EventArgs e)
        {
            int val;
            try
            {
                val = int.Parse(TransactionAmountBox.Text);
            }
            catch (Exception)
            {
                ShowMessage("* Input is not valid.");
                return;
            }

            ShowMessage(creditCard.Payoff(val));
            RefreshForm();
        }

        private void OnDebit(object sender, EventArgs e)
        {
            int val;
            try
            {
                val = int.Parse(TransactionAmountBox.Text);
            }
            catch (Exception)
            {
                ShowMessage("* Input is not valid.");
                return;
            }
            
            ShowMessage(creditCard.Debit(val));
            RefreshForm();
        }

        private void OnChangeCard(object sender, EventArgs e)
        {
            string newType = Card.Text;
            creditCard = Factory.CreateCreditCard(newType);
            CardIcon.ImageLocation = GetImage(newType);
            ShowMessage($"The card selected is {newType}.");
            RefreshForm();
        }

        private void OnResetCard(object sender, EventArgs e)
        {
            ShowMessage(creditCard.ResetCard());
            RefreshForm();
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowMessage(string message = "")
        {
            Alert.Text = message;
        }

        private string GetImage(string type)
        {
            if (type.Contains("Visa")) return "https://cdn4.iconfinder.com/data/icons/payment-method/160/payment_method_card_visa-128.png";
            else
                if (type.Contains("Master Card")) return "https://cdn4.iconfinder.com/data/icons/simple-peyment-methods/512/mastercard-128.png";
            else
                if (type.Contains("American Express")) return "https://cdn4.iconfinder.com/data/icons/payment-method/160/payment_method_american_express_card-128.png";
            else
                return "https://cdn0.iconfinder.com/data/icons/business-collection-2027/60/credit-card-4-128.png";
        }
    }

    public class Program
    {
        public static void Main(string[] args) => Application.Run(new GFrame());
    }
}
