using BookStore.Models;

namespace BookStore.Logic
{
		public interface IMailLogic
		{
			Task SendEmail(MailInfo mailInfo);
			Task SendEmailDatHangThanhCong(DonHang datHang, MailInfo mailInfo);
		}
	}
