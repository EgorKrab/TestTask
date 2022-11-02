using TestTask.Models;
namespace TestTask
{
    public class Data
    {
        public static void Initialize(MarketContext context)
        {
            if (!context.Markets.Any())
            {
                context.Markets.AddRange(
                    new Market
                    {
                        Name = "Картофанчик",
                        Price = 100,
                        Description = "На славу уродилася картошка!\nЗа кило заплати немножка!"
                    },
                    new Market
                    {
                        Name = "Редка",
                        Price = 60,
                        Description = "Кто ест хрен да редьку, тот хворает редко."
                    },
                    new Market
                    {
                        Name = "Огурец",
                        Price = 70,
                        Description = "Нет полезней и вкуснее. В праздник, и во дни поста."
                    },
                    new Market
                    {
                        Name = "Лук",
                        Price = 40,
                        Description = "Лук да баня - все правят!"
                    },
                    new Market
                    {
                        Name = "Кабачок",
                        Price = 60,
                        Description = "Я, друзья, кочан капусты\nНеобыкновенно вкусный."
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
