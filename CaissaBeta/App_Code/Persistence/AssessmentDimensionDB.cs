using System;
using System.Data;
using Caissa.Classes;

namespace Caissa.Persistence
{
    public class AssessmentDimensionDB
    {
        public int assessment_dimension_id
        {
            get;
            set;
        }

        #region Insert Assessment Dimension
        private void Insert(AssessmentDimension dimension)
        {
            string storedprocedure = "sp_InsertAssessmentDimension";

            System.Data.IDbConnection connection;
            System.Data.IDbCommand command;

            connection = Mapped.Connection(Mapped.conexao.ServerExplorer);

            command = Mapped.Command(storedprocedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(Mapped.Parameter("p_asd_title", dimension.Title, DbType.String, ParameterDirection.Input));
            command.Parameters.Add(Mapped.Parameter("p_asd_description", dimension.Description, DbType.String, ParameterDirection.Input));
            command.Parameters.Add(Mapped.Parameter("p_asd_id", "", DbType.Int32, ParameterDirection.Output));
            command.ExecuteNonQuery();

            int id = 0;

            foreach (var parameter in command.Parameters)
            {
                IDbDataParameter p = (IDbDataParameter)parameter;
                if (p.Direction == ParameterDirection.Output)
                    if (p.ParameterName == "p_asd_id")
                        id = Convert.ToInt32(p.Value);
            }

            connection.Close();

            assessment_dimension_id = id;
        }
        #endregion

        #region Update Assessment Dimension
        private void Update(AssessmentDimension dimension)
        {
            string storedprocedure = "sp_UpdateAssessmentDimension";

            System.Data.IDbConnection connection;
            System.Data.IDbCommand command;

            connection = Mapped.Connection(Mapped.conexao.ServerExplorer);

            command = Mapped.Command(storedprocedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(Mapped.Parameter("p_asd_id", dimension.Id, DbType.Int32, ParameterDirection.Input));
            command.Parameters.Add(Mapped.Parameter("p_asd_title", dimension.Title, DbType.String, ParameterDirection.Input));
            command.Parameters.Add(Mapped.Parameter("p_asd_description", dimension.Description, DbType.String, ParameterDirection.Input));
            command.ExecuteNonQuery();

            connection.Close();
        }
        #endregion

        #region Delete Assessment Dimension
        private void Delete(int dimension_id)
        {
            string storedprocedure = "sp_DeleteAssessmentDimension";

            System.Data.IDbConnection connection;
            System.Data.IDbCommand command;

            connection = Mapped.Connection(Mapped.conexao.ServerExplorer);

            command = Mapped.Command(storedprocedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(Mapped.Parameter("p_asd_id", dimension_id, DbType.Int32, ParameterDirection.Input));
            command.ExecuteNonQuery();

            connection.Close();
        }
        #endregion

        #region Select Assessment Dimension
        public DataSet Select()
        {
            System.Data.IDbConnection connection;
            System.Data.IDbCommand command;
            System.Data.IDataAdapter adapter;

            DataSet ds = new DataSet();

            string sql = string.Empty;

            connection = Mapped.Connection(Mapped.conexao.ServerExplorer);

            sql = "select asd_id, asd_title, asd_description"
                + " from tbl_assessment_dimension"
                + " where asd_active = 0;";

            command = Mapped.Command(sql, connection);

            adapter = Mapped.Adapter(command);
            adapter.Fill(ds);

            connection.Close();

            return ds;
        }
        #endregion

        public AssessmentDimensionDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}