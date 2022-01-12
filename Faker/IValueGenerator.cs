using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    // Самый общий интерфейс, с коллекцией объектов которого можно работать,
    // и вызывать, не используя Reflection.
    public interface IValueGenerator
    {
        object Generate(GeneratorContext context);
        // Позволяет реализовывать сколь угодно сложную логику определения,
        // подходит ли генератор. Таким образом можно работать с генераторами
        // коллекций аналогично генераторам примитивных типов.
        bool CanGenerate(Type type);
    }

    // Отдельный тип для параметров генератора упрощает добавление новых параметров
    // в контекст без изменения сигнатуры функции.
    public class GeneratorContext
    {
        // Для сохранения состояния генератора псевдослучайных чисел
        // и получения различных значений при нескольких последовательных вызовах.
        public Random Random { get; }

        public Type TargetType { get; }

        // Даем возможность генератору использовать все возможности Faker.
        // Необходимо для создания коллекций произвольных объектов,
        // но может удобно и в некоторых других случаях.
        public IFaker Faker { get; }

        public GeneratorContext(Random random, Type targetType, IFaker faker)
        {
            Random = random;
            TargetType = targetType;
            Faker = faker;
        }
    }
}
