using BuscaComic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuscaComic.Test.Common
{
    public class ObjectMother
    {
        public Character Thor { get; set; }

        public Character Hulk { get; set; }

        public Comic AgeOfHeroes { get; set; }

        public Comic FiveRonin { get; set; }

        public Comic APlusX { get; set; }

        public IEnumerable<Character> AllCharacters
        {
            get => new List<Character>() { Thor, Hulk };
        }

        public IEnumerable<Comic> AllComics
        {
            get => new List<Comic>() { AgeOfHeroes, FiveRonin, APlusX };
        }


        public IEnumerable<Comic> ThorComics
        {
            get => new List<Comic>() { AgeOfHeroes, APlusX };
        }

        public IEnumerable<Comic> HulkComics
        {
            get => new List<Comic>() { FiveRonin, APlusX };
        }

        public ObjectMother()
        {
            Thor = new Character
            {
                Id = 1009664,
                Name = "Thor",
                Description = "As the Norse God of thunder and lightning, Thor wields one of the greatest weapons ever made, the enchanted hammer Mjolnir. While others have described Thor as an over-muscled, oafish imbecile, he's quite smart and compassionate.  He's self-assured, and he would never, ever stop fighting for a worthwhile cause.",
                Thumbnail = new Thumbnail
                {
                    Path = new Uri("http://i.annihil.us/u/prod/marvel/i/mg/d/d0/5269657a74350"),
                    Extension = "jpg"
                },
                Events = new EventArray
                {
                    Items = new Event[]
                    {
                        new Event { Name = "Acts of Vengeance!" },
                        new Event { Name = "Atlantis Attacks" },
                        new Event { Name = "Avengers Disassembled"}
                    }
                }
            };

            Hulk = new Character
            {
                Id = 1009351,
                Name = "Hulk",
                Description = "Caught in a gamma bomb explosion while trying to save the life of a teenager, Dr. Bruce Banner was transformed into the incredibly powerful creature called the Hulk. An all too often misunderstood hero, the angrier the Hulk gets, the stronger the Hulk gets.",
                Thumbnail = new Thumbnail
                {
                    Path = new Uri("http://i.annihil.us/u/prod/marvel/i/mg/5/a0/538615ca33ab0"),
                    Extension = "jpg"
                },
                Events = new EventArray
                {
                    Items = new Event[]
                    {
                        new Event { Name = "Acts of Vengeance!" },
                        new Event { Name = "Age of X" },
                        new Event { Name = "Chaos War" }
                    }
                }
            };

            AgeOfHeroes = new Comic
            {
                Id = 30090,
                Title = "Age of Heroes (2010) #1",
                Description = "Eisner-winner & fan-favorite KURT BUSIEK RETURNS TO MARVEL!\r\nTHE HEROIC AGE IS HERE!\r\nThe Heroes are restored to their rightful place in this new era, and the world is safer for them.  They defeated Osborn & his Siege on Asgard, now they have one last foe to face: the Mayor of New York -- J. Jonah Jameson!  Also, MI13 come to the US, but one of them isn't leaving--they are defecting to the AVENGERS?! Plus Dr. Voodoo's Sorcerer Supreme duties infringe on \"date night\" and how much trouble can Spider-Man get into in one day? The answer: A LOT!\r\nRated T  ...$3.99",
                Format = "Comic",
                Thumbnail = new Thumbnail
                {
                    Path = new Uri("http://i.annihil.us/u/prod/marvel/i/mg/f/70/56afac804fff2"),
                    Extension = "jpg"
                },
                Characters = new Characters
                {
                    Items = new CharacterInDetail[]
                    {
                        new CharacterInDetail
                        {
                            Name = Thor.Name,
                            ResourceUri = new Uri($"http://gateway.marvel.com/v1/public/characters/{Thor.Id}")
                        }
                    }
                }
            };

            FiveRonin = new Comic
            {
                Id = 36365,
                Title = "5 Ronin (2010) #2",
                Description = "It is 17th century Japan, a time and place of violent upheaval. Into this strange and dangerous world come Wolverine, Pyslocke, Punisher, Hulk and Deadpool. Prepare for the Marvel heroes like you've never seen them before.",
                Format = "Comic",
                Thumbnail = new Thumbnail
                {
                    Path = new Uri("http://i.annihil.us/u/prod/marvel/i/mg/d/00/598e2bafe656c"),
                    Extension = "jpg"
                },
                Characters = new Characters
                {
                    Items = new CharacterInDetail[]
                    {
                        new CharacterInDetail
                        {
                            Name = Hulk.Name,
                            ResourceUri = new Uri($"http://gateway.marvel.com/v1/public/characters/{Hulk.Id}")
                        }
                    }
                }
            };

            APlusX = new Comic
            {
                Id = 43506,
                Title = "A+X (2012) #7",
                Description = "<ul><li>Artist Stefano Casseli (AVENGERS ASSEMBLE) and Mike Costa (G.I.: JOE: Cobra) show you the ever-loving blue-eyed Thing and the ever-lusting red-eyed Gambit playing the most dangerous game!</li><li>Thor and Iceman teamup in one of the most visually amazing tales you&rsquo;ve ever seen, courtesy of Christopher Yost (AVENGING SPIDER-MAN) and superstar artists-to be R&rsquo;John Bernales and Chris Turcotte!</li></ul>",
                Format = "Comic",
                Thumbnail = new Thumbnail
                {
                    Path = new Uri("http://i.annihil.us/u/prod/marvel/i/mg/6/70/584f133319afd"),
                    Extension = "jpg"
                },
                Characters = new Characters
                {
                    Items = new CharacterInDetail[]
                    {
                        new CharacterInDetail
                        {
                            Name = Thor.Name,
                            ResourceUri = new Uri($"http://gateway.marvel.com/v1/public/characters/{Thor.Id}")
                        },
                        new CharacterInDetail
                        {
                            Name = Hulk.Name,
                            ResourceUri = new Uri($"http://gateway.marvel.com/v1/public/characters/{Hulk.Id}")
                        }
                    }
                }
            };
        }
    }
}
