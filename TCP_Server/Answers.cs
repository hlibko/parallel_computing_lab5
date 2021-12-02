using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Server
{
    class Answers
    {
        readonly string[] answers =
         { 
              "Бесспорно",
              "Предрешено",
              "Никаких сомнений",
              "Определённо да",
              "Можешь быть уверен в этом",
              "Мне кажется — «да»",
              "Вероятнее всего",
              "Хорошие перспективы",
              "Знаки говорят — «да»",
              "Да",
              "Пока не ясно, попробуй снова",
              "Спроси позже",
              "Лучше не рассказывать",
              "Сейчас нельзя предсказать",
              "Сконцентрируйся и спроси опять",
              "Даже не думай",
              "Мой ответ — «нет»",
              "По моим данным — «нет»",
              "Перспективы не очень хорошие",
              "Весьма сомнительно"
         };

        public string GetAnswer()
        {
            int length = answers.Length;
            Random random = new Random();
            return answers[random.Next(length)];
        }

    }
}
