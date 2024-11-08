using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic
{
    public class FoodBL
    {
        FoodDA foodDA = new FoodDA();

        public List<Food> GetAll()
        {
            return foodDA.GetAll();
        }

        public Food GetByID(int id)
        {
            List<Food> list = GetAll();
            foreach (var food in list)
            {
                if (food.ID == id)
                    return food;
            }
            return null;
        }

        public List<Food> Find(string key)
        {
            List<Food> list = GetAll();
            List<Food> result = new List<Food>();
            foreach (var food in list)
            {
                if (
                    food.ID.ToString().Contains(key) || food.Name.Contains(key)
                    || food.Unit.Contains(key) || food.Price.ToString().Contains(key)
                    || food.Notes.Contains(key)
                   )
                    result.Add(food);
            }
            return result;
        }

        public int Insert(Food food)
        {
            return foodDA.Insert_Update_Delete(food,0);
        }

        public int Update(Food food)
        {
            return foodDA.Insert_Update_Delete(food,1);
        }

        public int Delete(Food food)
        {
            return foodDA.Insert_Update_Delete(food,2);
        }
    }
}
