using DataAccessInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using DataObjects.Kitchen;
using DataObjects;
using System.Text.RegularExpressions;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 02/1/2024
    /// Summary: Creation of the WeekFoodMenuAccessor class.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 02/05/2024
    /// What Was Changed: Added two more methods for the interface
    /// </summary>
    public class WeekFoodMenuAccessor : IWeekFoodMenuAccessor
    {
        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/05/2024
        /// Summary: Getting menu meals to view on the food menu.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/05/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<MenuMealVM> getMenuMeals(int menuID)
        {
            // Make return variable if appropriate
            List<MenuMealVM> menuMealVMs = new List<MenuMealVM>();

            // connection
            var conn = DatabaseConnection.GetConnection();

            // command text
            var cmdText = "sp_select_food_menu_meals";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@MenuID", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@MenuID"].Value = menuID;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MenuMealVM menuMealVM = new MenuMealVM();
                        menuMealVM.MealID = reader.GetInt32(0);
                        menuMealVM.MenuID = reader.GetInt32(1);
                        menuMealVM.RecipeID = reader.GetInt32(2);
                        menuMealVM.EmployeeID = reader.GetString(3);
                        menuMealVM.Category = reader.GetString(4);                        
                        menuMealVMs.Add(menuMealVM);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                if (menuMealVMs.Count > 0)
                {
                    foreach (var menuMealVM in menuMealVMs)
                    {
                        menuMealVM.Recipes = getMenuRecipes(menuMealVM.MenuID);
                    }
                }
            }
            return menuMealVMs;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/05/2024
        /// Summary: Creation of getMenuRecipes.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/05/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<Recipe> getMenuRecipes(int menuID)
        {
            // Make return variable if appropriate
            List<Recipe> recipes = new List<Recipe>();

            // connection
            var conn = DatabaseConnection.GetConnection();

            // command text
            var cmdText = "sp_select_recipes_by_menu";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@MenuID", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@MenuID"].Value = menuID;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Recipe recipe = new Recipe();
                        recipe.RecipeID = reader.GetInt32(0);
                        recipe.RecipeName = reader.GetString(1);
                        recipe.RecipeDescription = reader.GetString(2);
                        recipe.Calories = reader.GetInt32(3);
                        recipe.Allergens = reader.GetString(4);
                        recipe.Vegen = reader.GetBoolean(5);
                        recipe.PrepTime = reader.GetInt32(6);
                        recipe.MenuID = reader.GetInt32(7);
                        recipe.Category = reader.GetString(8);
                        recipe.KitchenItemID = reader.GetInt32(9);
                        recipes.Add(recipe);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return recipes;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/05/2024
        /// Summary: Getting a week food menu to view.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/05/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<int> getMenuIDs()
        {
            // Make return variable if appropriate
            List<int> menuIDs = new List<int>();

            // connection
            var conn = DatabaseConnection.GetConnection();

            // command text
            var cmdText = "sp_select_all_menu_ids";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int menuID = reader.GetInt32(0);
                    menuIDs.Add(menuID);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return menuIDs;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/05/2024
        /// Summary: Getting a week food menu to view.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/05/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public WeekFoodMenuVM getWeekFoodMenu(int menuID)
        {
            // Make return variable if appropriate
            WeekFoodMenuVM weekFoodMenuVM = new WeekFoodMenuVM();

            // connection
            var conn = DatabaseConnection.GetConnection();

            // command text
            var cmdText = "sp_select_food_menu";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@MenuID", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@MenuID"].Value = menuID;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        weekFoodMenuVM.MenuID = reader.GetInt32(0);
                        weekFoodMenuVM.DayOfMeal = reader.GetString(1);
                        weekFoodMenuVM.MenuName = reader.GetString(2);
                        weekFoodMenuVM.MenuType = reader.GetString(3);
                        weekFoodMenuVM.DateLastModified = reader.GetDateTime(4);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            weekFoodMenuVM.recipes = getMenuRecipes(weekFoodMenuVM.MenuID);

            return weekFoodMenuVM;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 01/31/2024
        /// Summary: Inserting a meal into the food menu.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 01/31/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public int InsertFoodItemIntoMenu(int MenuID, int RecipeID, string EmployeeID, string Category)
        {
            var conn = DatabaseConnection.GetConnection();

            var cmdText = "sp_add_meal_to_menu";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MenuID", SqlDbType.Int);
            cmd.Parameters.Add("@RecipeID", SqlDbType.Int);
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 50);

            cmd.Parameters["@MenuID"].Value = MenuID;
            cmd.Parameters["@RecipeID"].Value = RecipeID;
            cmd.Parameters["@EmployeeID"].Value = EmployeeID;
            cmd.Parameters["@Category"].Value = Category;

            var rows = 0;

            try
            {
                conn.Open();

                rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return -rows;
        }


        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 01/31/2024
        /// Summary: Inserting new food menu item.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 01/31/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public int InsertFoodMenu(string DayOfMeal, string MenuName, string MenuType, DateTime DateLastModified)
        {
            var conn = DatabaseConnection.GetConnection();

            var cmdText = "sp_insert_food_menu";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@DayOfMeal", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@MenuName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@MenuType", SqlDbType.NVarChar, 11);
            cmd.Parameters.Add("@DateLastModified", SqlDbType.Date);
            
            cmd.Parameters["@DayOfMeal"].Value = DayOfMeal;
            cmd.Parameters["@MenuName"].Value = MenuName;
            cmd.Parameters["@MenuType"].Value = MenuType;
            cmd.Parameters["@DateLastModified"].Value = DateLastModified;
            
            var id = 0;

            try
            {
                conn.Open();

                var newId = cmd.ExecuteScalar();

                id = Convert.ToInt32(newId);

                if (id == 0)
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return id;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 01/31/2024
        /// Summary: Adding recipes as menus are added with recipes.  There's a foreign key in the Recipe table for MenuID.
        /// A food menu can't have recipes without adding the recipes to the recipe table.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/29/2024
        /// What Was Changed: Changed from "sp_insert_recipe" to "sp_insert_recipe_for_menu" to be slightly more descriptive.
        /// </summary>
        public int InsertNewRecipeForMenu(RecipeVM recipe)
        {
            var conn = DatabaseConnection.GetConnection();

            var cmdText = "sp_insert_recipe_for_menu";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@RecipeName", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@RecipeDescription", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@Calories", SqlDbType.Int);
            cmd.Parameters.Add("@Allergens", SqlDbType.NVarChar, 500);
            cmd.Parameters.Add("@Vegen", SqlDbType.Bit);
            cmd.Parameters.Add("@PrepTime", SqlDbType.Int);
            cmd.Parameters.Add("@MenuID", SqlDbType.Int);
            cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@KitchenItemID", SqlDbType.Int);
            cmd.Parameters.Add("@RecipeSteps", SqlDbType.Text);

            cmd.Parameters["@RecipeName"].Value = recipe.RecipeName;
            cmd.Parameters["@RecipeDescription"].Value = recipe.RecipeDescription;
            cmd.Parameters["@Calories"].Value = recipe.Calories;
            cmd.Parameters["@Allergens"].Value = recipe.Allergens;
            cmd.Parameters["@Vegen"].Value = recipe.Vegen;
            cmd.Parameters["@PrepTime"].Value = recipe.PrepTime;
            cmd.Parameters["@MenuID"].Value = recipe.MenuID;
            cmd.Parameters["@Category"].Value = recipe.Category;
            cmd.Parameters["@KitchenItemID"].Value = recipe.KitchenItemID;
            cmd.Parameters["@RecipeSteps"].Value = recipe.RecipeSteps;

            var rows = 0;

            try
            {
                conn.Open();

                rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return -rows;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 04/19/2024
        /// Summary: Accessor method for getting all food menus.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 04/19/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<WeekFoodMenuVM> getWeekFoodMenus()
        {
            // Make return variable if appropriate
            List<WeekFoodMenuVM> weekFoodMenuVMs = new List<WeekFoodMenuVM>();

            // connection
            var conn = DatabaseConnection.GetConnection();

            // command text
            var cmdText = "sp_select_all_week_food_menus";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        WeekFoodMenuVM weekFoodMenuVM = new WeekFoodMenuVM();
                        weekFoodMenuVM.MenuID = reader.GetInt32(0);
                        weekFoodMenuVM.DayOfMeal = reader.GetString(1);
                        weekFoodMenuVM.MenuName = reader.GetString(2);
                        weekFoodMenuVM.MenuType = reader.GetString(3);
                        weekFoodMenuVM.DateLastModified = reader.GetDateTime(4);
                        weekFoodMenuVM.recipes = getMenuRecipes(weekFoodMenuVM.MenuID);
                        weekFoodMenuVMs.Add(weekFoodMenuVM);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return weekFoodMenuVMs;
        }
    }
}
