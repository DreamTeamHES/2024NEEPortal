using System.Runtime.CompilerServices;
using InstallationAPI.Models;
using DBContext;
using DBContext.Models;

namespace InstallationAPI.Converter
{
    public static class DTOConverter
    {
        //To Model
        public static InstallationAPI.Models.ElectricityProductionPlantM ToModel(this DBContext.Models.ElectricityProductionPlant entity)
        {

            return new InstallationAPI.Models.ElectricityProductionPlantM
            {
                XtfId = entity.XtfId,
                Address = entity.Address,
                PostCode = entity.PostCode,
                Municipality = entity.Municipality,
                Canton = entity.Canton,
                BeginningOfOperation = entity.BeginningOfOperation,
                InitialPower = entity.InitialPower,
                TotalPower = entity.TotalPower,
                MainCategory = entity.MainCategory,
                SubCategory = entity.SubCategory,
                PlantCategory = entity.PlantCategory,
                X = entity.X,
                Y = entity.Y,
            };
        }

        public static InstallationAPI.Models.MainCategoryCatalogueM ToModel(this DBContext.Models.MainCategoryCatalogue entity)
        {
            return new InstallationAPI.Models.MainCategoryCatalogueM
            {
                CatalogueId = entity.CatalogueId,
                De = entity.De,
            };
        }

        public static InstallationAPI.Models.PlantCategoryCatalogueM ToModel(this DBContext.Models.PlantCategoryCatalogue entity)
        {
            return new InstallationAPI.Models.PlantCategoryCatalogueM
            {
                CatalogueId = entity.CatalogueId,
                De = entity.De,
            };
        }

        public static InstallationAPI.Models.SubCategoryCatalogueM ToModel(this DBContext.Models.SubCategoryCatalogue entity)
        {
            return new InstallationAPI.Models.SubCategoryCatalogueM
            {
                CatalogueId = entity.CatalogueId,
                De = entity.De,
            };
        }

        //To Entity
        public static DBContext.Models.ElectricityProductionPlant ToEntity(this InstallationAPI.Models.ElectricityProductionPlantM model)
        {
            //take the de of the MainCategoryCatalogue where MainCategory is equal to the MainCategoryCatalogue.CatalogueId
            var mainCategoryCatalogue = model.MainCategory != null ? new DBContext.Models.MainCategoryCatalogue { De = model.MainCategory } : null;
            var subCategoryCatalogue = model.SubCategory != null ? new DBContext.Models.SubCategoryCatalogue { De = model.SubCategory } : null;
            var plantCategoryCatalogue = model.PlantCategory != null ? new DBContext.Models.PlantCategoryCatalogue { De = model.PlantCategory } : null;

            return new DBContext.Models.ElectricityProductionPlant
                {
                XtfId = model.XtfId,
                Address = model.Address,
                PostCode = model.PostCode,
                Municipality = model.Municipality,
                Canton = model.Canton,
                BeginningOfOperation = model.BeginningOfOperation,
                InitialPower = model.InitialPower,
                TotalPower = model.TotalPower,
                MainCategory = mainCategoryCatalogue.De,
                SubCategory = subCategoryCatalogue.De,
                PlantCategory = plantCategoryCatalogue.De,
                X = model.X,
                Y = model.Y,
            };
        }

        public static DBContext.Models.MainCategoryCatalogue ToEntity(this InstallationAPI.Models.MainCategoryCatalogueM model)
        {
            return new DBContext.Models.MainCategoryCatalogue
            {
                CatalogueId = model.CatalogueId,
                De = model.De,
            };
        }

        public static DBContext.Models.PlantCategoryCatalogue ToEntity(this InstallationAPI.Models.PlantCategoryCatalogueM model)
        {
            return new DBContext.Models.PlantCategoryCatalogue
            {
                CatalogueId = model.CatalogueId,
                De = model.De,
            };
        }

        public static DBContext.Models.SubCategoryCatalogue ToEntity(this InstallationAPI.Models.SubCategoryCatalogueM model)
        {
            return new DBContext.Models.SubCategoryCatalogue
            {
                CatalogueId = model.CatalogueId,
                De = model.De,
            };
        }

    }
}
