using BussinesObject.UI.Pages;
using Core.Selenium;
using OpenQA.Selenium;
using System.Drawing;

namespace Test.UiTests
{
    internal class TEST_TEST_HighlightElementAndScreen:BaseTest
    {
        [Test]
        public void GetScreenWithHighlight()
        {
            Pen pen = new Pen(System.Drawing.Color.DarkRed, 3);

            var page = new LoginPage().OpenPage();

            //размеры всего окна
            var windowWidth = Browser.Instance.Driver.Manage().Window.Size.Width;
            var windowHeight = Browser.Instance.Driver.Manage().Window.Size.Height;

            //размеры рабочей области страницы
            var contentWidth = ExecutreJS("return window.innerWidth");
            var contentHeight = ExecutreJS("return window.innerHeight");

            //создание пустого объекта с заданными размерами
            Bitmap bmpScreenshot = new Bitmap(contentWidth, contentHeight);

            //объект Griphics, без него не получить доступ к методу "скриншота" CopyFromScreen
            var g = Graphics.FromImage(bmpScreenshot);

            //копируем с экрана в созданный ранее объект
            //прописываю левый верхний угол по высоте, т.к. панель инструментов хрома и панель задач лишние, примерно равны
            g.CopyFromScreen(0, (windowHeight - contentHeight), 0, 0, Browser.Instance.Driver.Manage().Window.Size);

            //поиск элемента
            By PasswordInput = By.XPath("//input[@type='email']");
            var element = Browser.Instance.Driver.FindElement(PasswordInput);

            //рисуем рамочку по параметрам: левый верхний угол(x,y), ширина, высота
            g.DrawRectangle(pen, element.Location.X, element.Location.Y, element.Size.Width, element.Size.Height);

            //сохраняет в bin\Debug\net7.0
            bmpScreenshot.Save("Скрин.png");
        }

        //надо придумать нормальное название. Метод из browser отказался работать с этим
        public int ExecutreJS(string jsCode)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.Instance.Driver;
            var result = (Int64)js.ExecuteScript(jsCode);

            return (int)result;
        }
    }
}
