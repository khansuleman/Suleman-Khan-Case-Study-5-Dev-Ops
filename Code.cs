using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Linq;
using System.IO;
using System.Text;

namespace CaseStudySK
{

    public class Youtube
    {

        /*Here we have a method which we will call later in our console application. This method contains the entire code required to run web scrapping on a specific website.
        */
        public void YouTubeScraping()
        {
            /*Asks the user for input when selecting this option*/
            Console.Write("Enter something you would like to search: ");
            string word1 = Console.ReadLine();
            /*here we need to scrap videos from the search page. therefore we just take the user given query and stick it to the base url of youtube search query.*/
            String test_url_1 = "https://www.youtube.com/results?search_query=" + word1;
            /*this will declare the driver tool, open the page from url and declares the count for the loop*/
            IWebDriver driver;
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            int count = 1;
            driver.Url = test_url_1;
            /* Explicit Wait to ensure that the page is loaded completely by reading the DOM state */
            var timeout = 10000; /* Maximum wait time of 10 seconds */
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            Thread.Sleep(5000);
            /*the loop is based on this body. the videos are stored in this tag so we set this as the starting point for our loop.*/
            By elem_video_link = By.TagName("ytd-video-renderer");
            ReadOnlyCollection<IWebElement> videos = driver.FindElements(elem_video_link);

            /* Go through the Videos List and scrap the same to get the attributes of the videos in the search query and prepare the csv export. */

            var csv = new StringBuilder();

            foreach (IWebElement video in videos.Take(5))
            {
                /*here we create a few strings and give them the corresponding elemenet so our tool can scrap the data we want to have*/
                string str_title, str_views, str_author, str_link;
                IWebElement elem_video_author = video.FindElement(By.CssSelector("[class = 'long-byline style-scope ytd-video-renderer']"));
                str_author = elem_video_author.Text;

                IWebElement elem_video_title = video.FindElement(By.CssSelector("#video-title"));
                str_title = elem_video_title.Text;

                IWebElement elem_video_views = video.FindElement(By.XPath(".//*[@id='metadata-line']/span[1]"));
                str_views = elem_video_views.Text;

                IWebElement elem_link = video.FindElement(By.CssSelector("[class = 'yt-simple-endpoint style-scope ytd-video-renderer']"));
                str_link = elem_link.GetAttribute("href");

                /*here we create variables of the data we scrapped so we can export it so csv*/
                var total = ("******* Video " + count + " *******");
                var publisher = ("Video Publisher: " + str_author);
                var title = ("Video Title: " + str_title);
                var views = ("Video Views: " + str_views);
                var link = ("Video Link: " + str_link);

                csv.AppendLine(total);
                csv.AppendLine(publisher);
                csv.AppendLine(title);
                csv.AppendLine(views);
                csv.AppendLine(link);
                /*displaying the scrapped data in the console app*/
                Console.WriteLine("******* Video " + count + " *******");
                Console.WriteLine("Video Publisher: " + str_author);
                Console.WriteLine("Video Title: " + str_title);
                Console.WriteLine("Video Views: " + str_views);
                Console.WriteLine("Video Link: " + str_link);
                Console.WriteLine("\n");
                count++;


            }
            /*close the chrome window and send the acquired data to the csv file on this location*/
            driver.Quit();
            File.WriteAllText("D:/2_TM/devops/csv/youtube.csv", csv.ToString(), Encoding.UTF8);

        }
    }

    public class Indeed
    {


        public void IndeedScraping()
        {
            Console.Write("Enter something you would like to search: ");
            string word2 = Console.ReadLine();
            String test_url_1 = "https://be.indeed.com/jobs?q=" + word2 + "&fromage=3";
            IWebDriver driver;
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            int count = 1;
            driver.Url = test_url_1;
            /* Explicit Wait to ensure that the page is loaded completely by reading the DOM state */
            var timeout = 10000; /* Maximum wait time of 10 seconds */
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            Thread.Sleep(5000);

            By elem_body = By.XPath(".//*[@id = 'mosaic-provider-jobcards']/a");
            ReadOnlyCollection<IWebElement> alljobs = driver.FindElements(elem_body);

            /* Go through the jobs List and scrap the same to get the attributes of the jobs in the search query */

            var csv = new StringBuilder();

            foreach (IWebElement jobd in alljobs.Take(7))
            {
                string str_bedrijf, str_locatie, str_job, str_link;
                IWebElement elem_job = jobd.FindElement(By.XPath(".//*[@class='jobTitle jobTitle-newJob']/span[1]"));
                str_job = elem_job.Text;

                IWebElement elem_bedrijf = jobd.FindElement(By.CssSelector("[class = 'turnstileLink companyOverviewLink']"));
                str_bedrijf = elem_bedrijf.Text;

                IWebElement elem_locatie = jobd.FindElement(By.CssSelector("[class = 'companyLocation']"));
                str_locatie = elem_locatie.Text;

                IWebElement elem_link = jobd.FindElement(By.TagName("a"));
                str_link = elem_link.GetAttribute("href");


                var total = ("******* Job " + count + " *******");
                var titel = ("Job Titel: " + str_job);
                var bedrijf = ("Bedrijf: " + str_bedrijf);
                var locatie = ("Locatie: " + str_locatie);
                var link = ("Link: " + str_link);

                csv.AppendLine(link);
                csv.AppendLine(total);
                csv.AppendLine(titel);
                csv.AppendLine(bedrijf);
                csv.AppendLine(locatie);


                Console.WriteLine("******* Job " + count + " *******");
                Console.WriteLine("Job Titel: " + str_job);
                Console.WriteLine("Bedrijf: " + str_bedrijf);
                Console.WriteLine("Locatie: " + str_locatie);
                Console.WriteLine("Link: " + str_link);
                Console.WriteLine("\n");
                count++;

            }
            driver.Quit();
            File.WriteAllText("D:/2_TM/devops/csv/indeed.csv", csv.ToString(), Encoding.UTF8);

        }

    }

    public class Reddit
    {


        public void RedditScraping()
        {
            Console.Write("Enter something you would like to search: ");
            string word3 = Console.ReadLine();
            String test_url_1 = "https://www.reddit.com/search/?q=" + word3;
            IWebDriver driver;
            int count = 1;
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = test_url_1;
            /* Explicit Wait to ensure that the page is loaded completely by reading the DOM state */
            var timeout = 10000; /* Maximum wait time of 10 seconds */
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            Thread.Sleep(5000);

            By elem_body = By.CssSelector("[class = '_1poyrkZ7g36PawDueRza-J']");
            ReadOnlyCollection<IWebElement> posts = driver.FindElements(elem_body);

            /* Go through the posts List and scrap the same to get the attributes of the posts in the search query */

            var csv = new StringBuilder();

            foreach (IWebElement post in posts.Take(10))
            {
                string str_up, str_subr, str_uploader, str_date, str_title, str_link;

                IWebElement elem_link = post.FindElement(By.CssSelector("[class='SQnoC3ObvgnGjWt90zD9Z _2INHSNB8V5eaWp4P0rY_mE']"));
                str_link = elem_link.GetAttribute("href");

                IWebElement elem_title = post.FindElement(By.CssSelector("[class='_eYtD2XCVieq6emjKBH3m']"));
                str_title = elem_title.Text;

                IWebElement elem_uploader = post.FindElement(By.CssSelector("[class='_2tbHP6ZydRpjI44J3syuqC  _23wugcdiaj44hdfugIAlnX oQctV4n0yUb0uiHDdGnmE']"));
                str_uploader = elem_uploader.Text;

                IWebElement elem_up = post.FindElement(By.CssSelector("[class = '_vaFo96phV6L5Hltvwcox']"));
                str_up = elem_up.Text;

                IWebElement elem_subr = post.FindElement(By.CssSelector("[class = '_3ryJoIoycVkA88fy40qNJc _305seOZmrgus3clHOXCmfs']"));
                str_subr = elem_subr.GetAttribute("href");

                IWebElement elem_date = post.FindElement(By.CssSelector("[class = '_3jOxDPIQ0KaOWpzvSQo-1s']"));
                str_date = elem_date.Text;

                var total = ("******* Post " + count + " *******");
                var title = ("Title: " + str_title);
                var uploader = ("Uploader: " + str_uploader);
                var up = ("Upvotes: " + str_up);
                var link = ("Link: " + str_link);
                var sr = ("Subbredit: " + str_subr);
                var date = ("Date: " + str_date);
                csv.AppendLine(total);
                csv.AppendLine(title);
                csv.AppendLine(uploader);
                csv.AppendLine(up);
                csv.AppendLine(link);
                csv.AppendLine(sr);
                csv.AppendLine(date);


                Console.WriteLine("******* Post " + count + " *******");
                Console.WriteLine("Title: " + str_title);
                Console.WriteLine("Uploader: " + str_uploader);
                Console.WriteLine("Upvotes: " + str_up);
                Console.WriteLine("Link: " + str_link);
                Console.WriteLine("Subbredit: " + str_subr);
                Console.WriteLine("Date: " + str_date);
                Console.WriteLine("\n");
                count++;

            }
            driver.Quit();
            File.WriteAllText("D:/2_TM/devops/csv/reddit.csv", csv.ToString(), Encoding.UTF8);

        }

    }

}