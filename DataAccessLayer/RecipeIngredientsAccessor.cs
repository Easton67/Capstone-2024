using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataObjects.Kitchen;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Andrew Larson
    /// Created: 02/12/2024
    /// Summary: This is the accessor class for RecipeIngredients.
    /// Last Updated By: Andrew Larson
    /// Last Updated 02/12/2024
    /// What was changed: Initial Creation
    /// </summary> 
    public class RecipeIngredientsAccessor : IRecipeIngredientsAccessor
    {
        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/13/2024
        /// Summary: This method will retrieve all RecipeIngredientObjects for a specific RecipeID from the database.
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/13/2024
        /// What was changed: Initial Creation
        /// </summary>
        public List<RecipeIngredients> GetIngredientsByRecipeID(int recipeID)
        {
            List<RecipeIngredients> ingredientsList = new List<RecipeIngredients>();

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_select_ingredients_by_RecipeID";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RecipeID", SqlDbType.Int);
            cmd.Parameters["@RecipeID"].Value = recipeID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        RecipeIngredients ingredient = new RecipeIngredients()
                        {
                            IngredientID = reader.GetString(0)
                        };
                        ingredientsList.Add(ingredient);
                    }
                }
                else 
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An unexpected error occurred: {ex.Message}", ex);
            }
            finally
            { 
                conn.Close();
            }
            return ingredientsList;
        }

        /// <summary>
        /// Creator:            Matthew Baccam
        /// Created:            04/24/2024
        /// Summary:            Creation for sp_insert_ingredient stored procedure
        /// Last Updated By:    Matthew Baccam
        /// Last Updated:       04/24/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public bool InsertNewIngredient(RecipeIngredients ingredient)
        {
            var connection = DatabaseConnection.GetConnection();
            int rows = 0;
            try
            {
                var commandText = "sp_insert_ingredient";
                var cmd = new SqlCommand(commandText, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IngredientID", ingredient.IngredientID);
                cmd.Parameters.AddWithValue("@RecipeID", ingredient.RecipeID);
                connection.Open();

                rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new Exception("Insertion did not occur");
                }
                connection.Close();

                return rows == 1;

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
    }
}
