using System;
using System.Text;


namespace Practice4
{
    /// <summary>
    /// "Product". Представляет объект, который должен быть создан, и состоящий из компонентов/программ
    /// </summary>
    class Components
    {
        public bool WindowsMedia;
        public bool WindowsPowerShell;
        public bool MSMQ;
        public bool BitLocker;
        public bool AppLocker;
        public bool DirectAccess;
        public bool WindowsInk;
        public bool MicrosoftPassport;
        public bool BranchCache;
        public bool WindowsSpotlight;
        public bool Kortana;
        public bool MicrosoftStore;
        public bool MicrosoftEdge;
        public bool AssignedAccess;
        public bool HyperV;
        public bool WindowsToGo;

        /// <summary>
        /// Построение строки
        /// </summary>
        /// <returns>Строка компонентов и программ, принадлежащих конкретной версии Windows</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (WindowsMedia == true) sb.Append("WindowsMedia" + "\n");
            if (WindowsPowerShell == true) sb.Append("WindowsPowerShell" + "\n");
            if (MSMQ == true) sb.Append("MSMQ" + "\n");
            if (BitLocker == true) sb.Append("BitLocker" + "\n");
            if (AppLocker == true) sb.Append("AppLocker" + "\n");
            if (DirectAccess == true) sb.Append("DirectAccess" + "\n");
            if (WindowsInk == true) sb.Append("WindowsInk" + "\n");
            if (MicrosoftPassport == true) sb.Append("MicrosoftPassport" + "\n");
            if (BranchCache == true) sb.Append("BranchCache" + "\n");
            if (WindowsSpotlight == true) sb.Append("WindowsSpotlight" + "\n");
            if (Kortana == true) sb.Append("Kortana" + "\n");
            if (MicrosoftStore == true) sb.Append("MicrosoftStore" + "\n");
            if (MicrosoftEdge == true) sb.Append("MicrosoftEdge" + "\n");
            if (AssignedAccess == true) sb.Append("AssignedAccess" + "\n");
            if (HyperV == true) sb.Append("HyperV" + "\n");
            if (WindowsToGo == true) sb.Append("WindowsToGo" + "\n");
            return sb.ToString();
        }
    }

    /// <summary>
    /// "Builder". Абстрактный класс WindowsBuilder объявляет интерфейс для создания различных частей объекта Components
    /// </summary>
    abstract class WindowsBuilder
    {
        protected Components comp;
        /// <summary>
        /// Метод получения результата
        /// </summary>
        /// <returns></returns>
        public Components GetComponents()
        {
            return comp;
        }
        /// <summary>
        /// Метод создания объекта Components
        /// </summary>
        public void CreateComponents()
        {
            comp = new Components();
        }
        /// <summary>
        /// Метод определения набора компонентов и программ для версии Windows
        /// </summary>
        public abstract void BuildOS();
    }

    /// <summary>
    /// "ConcreteBuilder". Конкретный строить Windows Home
    /// </summary>
    class WindowsHomeBuilder : WindowsBuilder
    {
        /// <summary>
        /// Переопределенный набор компонентов и программ для Windows Home
        /// </summary>
        public override void BuildOS()
        {
            comp.WindowsMedia = true;
            comp.WindowsPowerShell = true;
            comp.MSMQ = true;
            comp.WindowsInk = true;
            comp.MicrosoftPassport = true;
            comp.WindowsSpotlight = true;
            comp.Kortana = true;
            comp.MicrosoftStore = true;
            comp.MicrosoftEdge = true;
        }
    }

    /// <summary>
    /// "ConcreteBuilder". Конкретный строить Windows Pro
    /// </summary>
    class WindowsProBuilder : WindowsBuilder
    {
        /// <summary>
        /// Переопределенный набор компонентов и программ для Windows Pro
        /// </summary>
        public override void BuildOS()
        {
            comp.WindowsMedia = true;
            comp.WindowsPowerShell = true;
            comp.MSMQ = true;
            comp.BitLocker = true;
            comp.WindowsInk = true;
            comp.MicrosoftPassport = true;
            comp.WindowsSpotlight = true;
            comp.Kortana = true;
            comp.MicrosoftStore = true;
            comp.MicrosoftEdge = true;
            comp.AssignedAccess = true;
            comp.HyperV = true;
        }
    }

    /// <summary>
    /// "ConcreteBuilder". Конкретный строить Windows Enterprise 
    /// </summary>
    class WindowsEnterpriseBuilder : WindowsBuilder
    {
        /// <summary>
        /// Переопределенный набор компонентов и программ для Windows Enterprise
        /// </summary>
        public override void BuildOS()
        {
            comp.WindowsMedia = true;
            comp.WindowsPowerShell = true;
            comp.MSMQ = true;
            comp.BitLocker = true;
            comp.AppLocker = true;
            comp.DirectAccess = true;
            comp.WindowsInk = true;
            comp.MicrosoftPassport = true;
            comp.BranchCache = true;
            comp.MicrosoftStore = true;
            comp.MicrosoftEdge = true;
            comp.AssignedAccess = true;
            comp.HyperV = true;
            comp.WindowsToGo = true;
        }
    }

    /// <summary>
    /// "Director". Отвечает за выполнение шагов построения
    /// </summary>
    class Director
    {
        private WindowsBuilder builder;
        /// <summary>
        /// Выбор вектора построения для конкретной версии Windows
        /// </summary>
        /// <param name="version">Версия Windows</param>
        public void SetWindowsBuilder(string version)
        {
            switch (version)
            {
                case "home":
                    this.builder = new WindowsHomeBuilder();
                    break;
                case "pro":
                    this.builder = new WindowsProBuilder();
                    break;
                case "enterprise":
                    this.builder = new WindowsEnterpriseBuilder();
                    break;
            }
        }
        /// <summary>
        /// Метод получения результата
        /// </summary>
        /// <returns>Объект класса Components</returns>
        public Components GetComponents()
        {
            return builder.GetComponents();
        }
        /// <summary>
        /// Построение объекта
        /// </summary>
        public void BuildWindows()
        {
            builder.CreateComponents();
            builder.BuildOS();
        }
    }

    class Program
    {
        /// <summary>
        /// Точка входа программы
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Home, Pro or Enterprise?");
            string version = Console.ReadLine().ToLower();
            if (version != "home" && version != "pro" && version != "enterprise")
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine("\nComponents:");
                Director d = new Director();
                d.SetWindowsBuilder(version);
                d.BuildWindows();
                Components compp = d.GetComponents();
                Console.WriteLine(compp.ToString());  
            }
            Console.ReadKey();
        }
    }
}
