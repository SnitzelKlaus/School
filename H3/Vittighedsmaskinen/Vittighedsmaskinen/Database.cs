using Vittighedsmaskinen.Models;

namespace Vittighedsmaskinen
{
    public class Database
    {
        public List<Joke> Jokes
        {
            get
            {
                List<Joke> jokes = new List<Joke>();
                
                // Danish Jokes
                jokes.Add(new Joke(1, "Hvad er det bedste ved at være en mand? At være en mand.", "Mande-Jokes", "dk"));
                jokes.Add(new Joke(2, "Hvorfor har blondiner stiger med når de handler? - Fordi priserne er så høje!", "Blondine-Jokes", "dk"));
                jokes.Add(new Joke(3, "Hvad er det mindst talte sprog i verden? – Tegnsprog", "Dad-Jokes", "dk"));
                jokes.Add(new Joke(4, "Hvorfor er fisk så grimme? – De er vandskabt", "Dad-Jokes", "dk"));
                jokes.Add(new Joke(5, "Hvad er forskellen på en løve og en giraf? – En giraf kan løve men en løve kan ikke giraf.", "Dad-Jokes", "dk"));
                jokes.Add(new Joke(6, "En gang skrev en lille dreng til julemanden ”Gider du være sød og give mig en lillesøster?”. Så skrev julemanden tilbage ”Okay, lån mig lige din mor”", "Dirty-Jokes", "dk"));
                jokes.Add(new Joke(7, "Hvad er ligheden mellem en kvinde og en mobiltelefon? – når man lige har lært dem at kende kommer der en ny og bedre model.", "Dirty-Jokes", "dk"));
                jokes.Add(new Joke(8, "-Eva: Adam elsker du mig? -Adam: nej -Eva(grædende): Hvorfor dyrker du så sex med mig? -Adam: Kan du se andre?", "Dirty-Jokes", "dk"));
                jokes.Add(new Joke(9, "Hvorfor spiser hajer ikke sorte mennesker? – De tror det er hval lort", "Racist-Jokes", "dk"));
                jokes.Add(new Joke(10, "Hvad gør du hvis du ser dit tv svæve i rummet? – Tænder lyset og skyder negeren!", "Racist-Jokes", "dk"));

                // English Jokes
                jokes.Add(new Joke(11, "My wife said I was immature. So I told her to get out of my fort.", "Dad-Jokes", "en"));
                jokes.Add(new Joke(12, "What rock group has four men that don't sing? - Mount Rushmore.", "Dad-Jokes", "en"));
                jokes.Add(new Joke(13, "Why couldn't the bicycle stand up by itself? - It was two tired!", "Dad-Jokes", "en"));
                jokes.Add(new Joke(14, "My grief counselor died. He was so good, I don’t even care.", "Dark-Jokes", "en"));
                jokes.Add(new Joke(15, "Today, I asked my phone “Siri, why am I still single?” and it activated the front camera.", "Dark-Jokes", "en"));
                jokes.Add(new Joke(16, "Why did the man miss the funeral? He wasn’t a mourning person.", "Dark-Jokes", "en"));
                jokes.Add(new Joke(17, "When does a joke become a dad joke? When it leaves you and never comes back.", "Dark-Jokes", "en"));
                jokes.Add(new Joke(18, "They laughed at my crayon drawing. I laughed at their chalk outline.", "Dark-Jokes", "en"));
                jokes.Add(new Joke(19, "I have many jokes about unemployed people—sadly none of them work.", "Dark-Jokes", "en"));
                jokes.Add(new Joke(20, "I made a website for orphans. It doesn’t have a home page.", "Dark-Jokes", "en"));

                return jokes;
            }
        }
    }
}
