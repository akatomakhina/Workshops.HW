using System;

namespace MemoryLeakExample
{
    #region NewMailEventArgs

    public sealed class NewMailEventArgs : EventArgs
    {
        #region fields
        private readonly string mailFrom;
        private readonly string mailTo;
        private readonly string mailSubject;
        #endregion

        #region ctor
        public NewMailEventArgs(string from, string to, string subject)
        {
            mailFrom = from;
            mailTo = to;
            mailSubject = subject;
        }
        #endregion

        #region properties
        public string From { get { return mailFrom; } }
        public string To { get { return mailTo; } }
        public string Subject { get { return mailSubject; } }
        #endregion
    }
    #endregion

    #region MailManager
    public class MailManager
    {
        public event EventHandler<NewMailEventArgs> NewMail = delegate { };

        protected virtual void OnNewMail(NewMailEventArgs e)
        {
            EventHandler<NewMailEventArgs> temp = NewMail;
            temp?.Invoke(this, e);
        }

        public void SimulateNewMail(string from, string to, string subject)
        {
            OnNewMail(new NewMailEventArgs(from, to, subject));
        }
    }
    #endregion

    #region Listeners
    public class Fax
    {
        public Fax() { }

        public void Register(MailManager mail)
        {
            mail.NewMail += FaxMsg;
        }

        public void Unregister(MailManager mail)
        {
            mail.NewMail -= FaxMsg;
        }

        private void FaxMsg(object sender, NewMailEventArgs eventArgs)
        {
            Console.WriteLine("Faxing mail message:");
            Console.WriteLine("From = {0}, To = {1}, Subject = {2}", eventArgs.From, eventArgs.To, eventArgs.Subject);
        }
    }
    #endregion
}
