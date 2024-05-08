using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects.Kitchen;
using DataAccessInterfaces;
using System.Text.RegularExpressions;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 02/1/2024
    /// Summary: Creation of the RecipeAccessor class.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 02/1/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class RecipeAccessor : IRecipeAccessor
    {       
        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/19/2024
        /// Summary: Deleting recipes by their name.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/19/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public int deleteRecipeByName(string recipeName)
        {
            var List = new List<RecipeVM>();

            var conn = DatabaseConnection.GetConnection();

            var cmdText = "sp_delete_recipe";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RecipeName", SqlDbType.NVarChar, 100);
            cmd.Parameters["@RecipeName"].Value = recipeName;

            int rows = 0;

            try
            {
                conn.Open();

                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 01/31/2024
        /// Summary: Selecting all recipes.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/27/2024
        /// What Was Changed: Added RecipeSteps
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/05/2024
        /// What Was Changed: Made it accept nullables
        /// </summary>
        public List<RecipeVM> SelectRecipes()
        {
            var List = new List<RecipeVM>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_all_recipes";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        RecipeVM recipeVM = new RecipeVM();
                        recipeVM.RecipeID = reader.GetInt32(0);
                        recipeVM.RecipeName = reader.GetString(1);
                        recipeVM.RecipeDescription = reader.GetString(2);
                        recipeVM.Calories = reader.GetInt32(3);
                        recipeVM.Allergens = reader.GetString(4);
                        recipeVM.Vegen = reader.GetBoolean(5);
                        recipeVM.PrepTime = reader.GetInt32(6);
                        recipeVM.MenuID = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
                        recipeVM.Category = reader.GetString(8);
                        recipeVM.KitchenItemID = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
                        recipeVM.RecipeSteps = reader.GetString(10);
                        recipeVM.RecipeImage = reader.IsDBNull(11) ? "" : reader.GetString(11);
                        List.Add(recipeVM);
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
            return List;
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/13/2024
        /// Summary: This method will retrieve the recipe details for a specified recipe
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/13/2024
        /// What was changed: Added the GetRecipeDetailsAndInstructionsByRecipeID method
        /// </summary> 
        public Recipe GetRecipeDetailsAndInstructionsByRecipeID(int recipeID)
        {
            Recipe recipe = null;

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_select_recipe_details_and_instructions_by_RecipeID";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RecipeID", SqlDbType.Int);
            cmd.Parameters["@RecipeID"].Value = recipeID;
            
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    recipe = new Recipe()
                    {
                        RecipeID = recipeID,
                        RecipeImage = reader.GetString(0),
                        RecipeSteps = reader.GetString(1),
                        RecipeName = reader.GetString(2)
                    };
                }
                else
                {
                    throw new ArgumentException("Recipe Not Found");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error retrieving recipe details and instructions.", ex);
            }
            finally
            {
                conn.Close();
            }
            return recipe;
        }

        /// <Summary>
        /// Creator: Matthew Baccam
        /// Created: 02/08/2024
        /// Summary: Initial Creation
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/08/2024
        /// What Was Changed: Initial Creation
        /// Last Updated By:    Matthew Baccam
        /// Last Updated:       04/24/2024
        /// What Was Changed:   Added a return value so we can insert ingredients
        /// <Summary>
        public int InsertRecipe(Recipe recipe)
        {
            int rows = 0;

            var connection = DatabaseConnection.GetConnection();
            var commandText = "sp_insert_recipe";
            var cmd = new SqlCommand(commandText, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RecipeIDCreated", SqlDbType.Int).Direction = ParameterDirection.Output;//The return var from the sql sproc

            cmd.Parameters.AddWithValue("@RecipeName", recipe.RecipeName);
            cmd.Parameters.AddWithValue("@RecipeDescription", recipe.RecipeDescription);
            cmd.Parameters.AddWithValue("@Calories", recipe.Calories);
            cmd.Parameters.AddWithValue("@PrepTime", recipe.PrepTime);
            cmd.Parameters.AddWithValue("@Allergens", recipe.Allergens);
            cmd.Parameters.AddWithValue("@Vegen", recipe.Vegen);
            cmd.Parameters.AddWithValue("@RecipeImage", recipe.RecipeImage == "" ? "" : recipe.RecipeImage);
            cmd.Parameters.AddWithValue("@RecipeSteps", recipe.RecipeSteps);
            cmd.Parameters.AddWithValue("@Category", recipe.Category);
            try
            {
                connection.Open();

                rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new Exception("Failed to create the recipe");
                }
                int recipeIDCreated = Convert.ToInt32(cmd.Parameters["@RecipeIDCreated"].Value);
                return recipeIDCreated;//is the number of the last Identity record inserted or -1 if failed in sproc
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/18/2024
        /// Summary: Method for selecting recipes by their categories.
        /// Last Updated By: Ethan McElree
        /// Last Updated 03/18/2024
        /// What was changed: Initial Creation
        /// </summary>
        public List<RecipeVM> SelectRecipesByCategory(string category)
        {
            if(category == "All")
            {
                return SelectRecipes();
            }

            var List = new List<RecipeVM>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_recipes_by_category";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 50);
            cmd.Parameters["@Category"].Value = category;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        RecipeVM recipeVM = new RecipeVM();
                        recipeVM.RecipeID = reader.GetInt32(0);
                        recipeVM.RecipeName = reader.GetString(1);
                        recipeVM.RecipeDescription = reader.GetString(2);
                        recipeVM.Calories = reader.GetInt32(3);
                        recipeVM.Allergens = reader.GetString(4);
                        recipeVM.Vegen = reader.GetBoolean(5);
                        recipeVM.PrepTime = reader.GetInt32(6);
                        recipeVM.MenuID = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
                        recipeVM.Category = reader.GetString(8);
                        recipeVM.KitchenItemID = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
                        recipeVM.RecipeSteps = reader.GetString(10);
                        recipeVM.RecipeImage = reader.IsDBNull(11) ? "" : reader.GetString(11);
                        List.Add(recipeVM);
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
            return List;
        }
    }
}
