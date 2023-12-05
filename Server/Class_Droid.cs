using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1Server
{
    internal class Class_Droid
    {
        public string nomber;
        public string action;

        public Class_Droid() { nomber = "0"; action = "Простой"; }

        public Class_Droid(string nomber) { this.nomber = nomber; action = "Простой"; }
        public Class_Droid(string nomber, string action)
        {
            this.nomber = nomber;
            this.action = action;
        }

        public void Tell_Server()
        {
            if (this.action == "Движение")
            {
                Console.WriteLine($"Номер дроида: {nomber} Действие: {action} Результат: Продвинулся на 10 единиц");
            }
            if (this.action == "Атака")
            {
                Console.WriteLine($"Номер дроида: {nomber} Действие: {action} Результат: Нанес 10 единиц урона");
            }
            if (this.action == "Поворот")
            {
                Console.WriteLine($"Номер дроида: {nomber} Действие: {action} Результат: Повернулся на 10 градусов");
            }
        }

        public string Tell()
        {
            if (this.action == "Движение") {return $"Номер дроида: {nomber} Действие: {action} Результат: Продвинулся на 10 единиц";}
            if (this.action == "Атака") {return $"Номер дроида: {nomber} Действие: {action} Результат: Нанес 10 единиц урона";}
            if (this.action == "Поворот") {return $"Номер дроида: {nomber} Действие: {action} Результат: Повернулся на 10 градусов";}
            else {return "Неизвестное действие. Попробуйте еще раз...";}
        }
    }
}
