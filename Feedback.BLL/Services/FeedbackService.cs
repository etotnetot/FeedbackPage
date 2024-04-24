using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback.BLL.Services
{
    internal class FeedbackService : IFeedbackService
    {
        public FeedbackService() { 

        }

        //Если совокупный набор данных(Email + Телефон) совпадают, то новый контакт в таблицу не добавлять.
        public bool CheckIfContactExists()
        {
            return false;
        }
    }
}
