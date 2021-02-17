﻿using Dapper;
using Oneonones.Persistence.Base;
using Oneonones.Persistence.Contracts.Databases;
using Oneonones.Persistence.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Oneonones.Persistence.Databases
{
    public class EmployeesDatabase : SqlBase, IEmployeesDatabase
    {
        private const string obtainAllQuery = @"
            SELECT
                email AS Email,
                name AS Name
            FROM
                employees
        ";

        private const string obtainQuery = @"
            SELECT
                email AS Email,
                name AS Name
            FROM
                employees
            WHERE
                email = @email
        ";

        private const string insertQuery = @"
            INSERT INTO
                employees
            VALUES (
                @email,
                @name
            )
        ";

        private const string updateQuery = @"
            UPDATE
                employees
            SET
                name = @name
            WHERE
                email = @email
        ";

        private const string deleteQuery = @"
            DELETE FROM
                employees
            WHERE
                email = @email
        ";

        public async Task<IList<EmployeeModel>> ObtainAll()
        {
            var employeeModelList = await Query<EmployeeModel>(obtainAllQuery);
            return employeeModelList;
        }

        public async Task<EmployeeModel> Obtain(string email)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@email", email, DbType.AnsiString);

            var employeeModel = await QueryFirst<EmployeeModel>(obtainQuery, parameters);
            return employeeModel;
        }

        public async Task<int> Insert(EmployeeModel employee)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@email", employee.Email, DbType.AnsiString);
            parameters.Add("@name", employee.Name, DbType.AnsiString);

            var rowsAffected = await Execute(insertQuery, parameters);
            return rowsAffected;
        }

        public async Task<int> Update(EmployeeModel employee)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@email", employee.Email, DbType.AnsiString);
            parameters.Add("@name", employee.Name, DbType.AnsiString);

            var rowsAffected = await Execute(updateQuery, parameters);
            return rowsAffected;
        }

        public async Task<int> Delete(string email)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@email", email, DbType.AnsiString);

            var rowsAffected = await Execute(deleteQuery, parameters);
            return rowsAffected;
        }
    }
}