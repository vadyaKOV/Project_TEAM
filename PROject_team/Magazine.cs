using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Article;

namespace Magazine
{
    internal class Magazine
    {
        private string nameMagazine;
        private Frequency exit;
        private DateTime dateExit;
        private int tiraj;
        private Article.Article[] mas;
        public Magazine()
        {
            nameMagazine = "DanikNEWS";
            exit = Frequency.Weekly;
            dateExit = DateTime.Today;
            tiraj = 1000;
            mas = new Article.Article[0];
        }
        public Magazine(string nameMagazine, Frequency exit, DateTime dateExit, int tiraj)
        {
            this.nameMagazine = nameMagazine;
            this.exit = exit;
            this.dateExit = dateExit;
            this.tiraj = tiraj;
            mas = new Article.Article[0];
        }
        public string NameMagazine { get => nameMagazine; set { nameMagazine=value; } }
        public Frequency Exit { get => exit; set { exit = value; } }
        public DateTime DateExit { get => dateExit; set { dateExit = value; } }
        public int Tiraj { get => tiraj; set { tiraj = value; } }
        public Article.Article[] Articles
        {
            get => mas;
            set { mas = value; }
        }
        public double Ranked
        {
            get
            {
                if (Articles.Length == 0) return 0;
                double sum = 0;
                foreach (var item in Articles)
                {
                    sum+= item.Mark;
                }
                return sum/Articles.Length;
            }
        }
        public void AddArticles(params Article.Article[] Article)
        {
            Array.Resize(ref mas, mas.Length + Article.Length);
            Array.Copy(Article, 0, mas, mas.Length - Article.Length, Article.Length);
        }
        public virtual string ToShortString()
        {
            return ($"\n Название: {NameMagazine}\n Переодичность выхода : {Exit}\n Дата выхода : {DateExit}\n Количество экземпляров: {Tiraj}\n Средняя оценка: {Ranked}");
        }

        private string ArticlesToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Articles != null && Articles.Length > 0) // Проверка на null и пустоту
            {
                foreach (var item in Articles)
                {
                    if (item != null) // Проверка на null для каждого элемента
                    {
                        sb.AppendLine(item.ToString() + "\n");
                    }
                }
            }
            else sb.AppendLine("Нету статей");
            return sb.ToString();
        }
        public override string ToString()
        {
            return ($"Название: {NameMagazine}\n Частота выхода: {exit}\n Дата выхода: {dateExit}\n Количество  {tiraj}\n Статьи:\n {ArticlesToString()}");
        }
        public bool this[Frequency x]
        {
            get { return x == Exit; }
        }
    }
}
