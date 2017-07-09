
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/02/2017 20:29:54
-- Generated from EDMX file: E:\KhodroClinic\CarProjectR1\CarProject\DBSEF\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CarAutomation];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AirConditioningSystem_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AirConditioningSystem] DROP CONSTRAINT [FK_AirConditioningSystem_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_AirConditioningSystemDetail_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AirConditioningSystemDetail] DROP CONSTRAINT [FK_AirConditioningSystemDetail_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_AutoService_ServicesCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AutoService] DROP CONSTRAINT [FK_AutoService_ServicesCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_AutoServiceCars_AutoService]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AutoServiceCars] DROP CONSTRAINT [FK_AutoServiceCars_AutoService];
GO
IF OBJECT_ID(N'[dbo].[FK_AutoServiceCars_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AutoServiceCars] DROP CONSTRAINT [FK_AutoServiceCars_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_AutoServicePackUserComments_AutoServicePack]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AutoServicePackUserComments] DROP CONSTRAINT [FK_AutoServicePackUserComments_AutoServicePack];
GO
IF OBJECT_ID(N'[dbo].[FK_AutoServicePackUserComments_AutoServicePackUserComments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AutoServicePackUserComments] DROP CONSTRAINT [FK_AutoServicePackUserComments_AutoServicePackUserComments];
GO
IF OBJECT_ID(N'[dbo].[FK_AutoServicePackUserComments_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AutoServicePackUserComments] DROP CONSTRAINT [FK_AutoServicePackUserComments_User];
GO
IF OBJECT_ID(N'[dbo].[FK_AutoServices_AutoService]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AutoServices] DROP CONSTRAINT [FK_AutoServices_AutoService];
GO
IF OBJECT_ID(N'[dbo].[FK_AutoServices_AutoServicePack]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AutoServices] DROP CONSTRAINT [FK_AutoServices_AutoServicePack];
GO
IF OBJECT_ID(N'[dbo].[FK_AutoServicesUserComments_AutoService]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AutoServicesUserComments] DROP CONSTRAINT [FK_AutoServicesUserComments_AutoService];
GO
IF OBJECT_ID(N'[dbo].[FK_AutoServicesUserComments_AutoServicesUserComments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AutoServicesUserComments] DROP CONSTRAINT [FK_AutoServicesUserComments_AutoServicesUserComments];
GO
IF OBJECT_ID(N'[dbo].[FK_AutoServicesUserComments_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AutoServicesUserComments] DROP CONSTRAINT [FK_AutoServicesUserComments_User];
GO
IF OBJECT_ID(N'[dbo].[FK_BasketItems_Baskets]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BasketItems] DROP CONSTRAINT [FK_BasketItems_Baskets];
GO
IF OBJECT_ID(N'[dbo].[FK_BasketItems_Discount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BasketItems] DROP CONSTRAINT [FK_BasketItems_Discount];
GO
IF OBJECT_ID(N'[dbo].[FK_Baskets_Baskets]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Baskets] DROP CONSTRAINT [FK_Baskets_Baskets];
GO
IF OBJECT_ID(N'[dbo].[FK_Baskets_DaysOfWeek]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Baskets] DROP CONSTRAINT [FK_Baskets_DaysOfWeek];
GO
IF OBJECT_ID(N'[dbo].[FK_Baskets_Discount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Baskets] DROP CONSTRAINT [FK_Baskets_Discount];
GO
IF OBJECT_ID(N'[dbo].[FK_Baskets_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Baskets] DROP CONSTRAINT [FK_Baskets_User];
GO
IF OBJECT_ID(N'[dbo].[FK_BrakeSystem_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BrakeSystem] DROP CONSTRAINT [FK_BrakeSystem_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_CarAirbags_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarAirbags] DROP CONSTRAINT [FK_CarAirbags_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_CarAudioSystem_Cars_CarsId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarAudioSystem] DROP CONSTRAINT [FK_CarAudioSystem_Cars_CarsId];
GO
IF OBJECT_ID(N'[dbo].[FK_CarComments_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarComments] DROP CONSTRAINT [FK_CarComments_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_CarComments_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarComments] DROP CONSTRAINT [FK_CarComments_User];
GO
IF OBJECT_ID(N'[dbo].[FK_CarDetails_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarDetails] DROP CONSTRAINT [FK_CarDetails_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_CarEngine_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarEngine] DROP CONSTRAINT [FK_CarEngine_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_CarGearBox_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarGearBox] DROP CONSTRAINT [FK_CarGearBox_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_CarLightingSystem_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarLightingSystem] DROP CONSTRAINT [FK_CarLightingSystem_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_CarModel_CarBrand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarModel] DROP CONSTRAINT [FK_CarModel_CarBrand];
GO
IF OBJECT_ID(N'[dbo].[FK_CarPhysicalDetails_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarPhysicalDetails] DROP CONSTRAINT [FK_CarPhysicalDetails_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_CarPrice_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarPrice] DROP CONSTRAINT [FK_CarPrice_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_Cars_CarModel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_Cars_CarModel];
GO
IF OBJECT_ID(N'[dbo].[FK_Cars_Country]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_Cars_Country];
GO
IF OBJECT_ID(N'[dbo].[FK_CarSeatOptions_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarSeatOptions] DROP CONSTRAINT [FK_CarSeatOptions_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_CarSensorsSystem_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarSensorsSystem] DROP CONSTRAINT [FK_CarSensorsSystem_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_CarsInSameClass_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarsInSameClass] DROP CONSTRAINT [FK_CarsInSameClass_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_CarsInSameClass_Cars1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarsInSameClass] DROP CONSTRAINT [FK_CarsInSameClass_Cars1];
GO
IF OBJECT_ID(N'[dbo].[FK_CarsPro_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarsPro] DROP CONSTRAINT [FK_CarsPro_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_CarsQnA_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarsQnA] DROP CONSTRAINT [FK_CarsQnA_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_CarsQnA_CarsQnA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarsQnA] DROP CONSTRAINT [FK_CarsQnA_CarsQnA];
GO
IF OBJECT_ID(N'[dbo].[FK_CarsReview_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarsReview] DROP CONSTRAINT [FK_CarsReview_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_CarsReviewPoint_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarsReviewPoint] DROP CONSTRAINT [FK_CarsReviewPoint_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_CarsReviewPoint_CarsReviewPoint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarsReviewPoint] DROP CONSTRAINT [FK_CarsReviewPoint_CarsReviewPoint];
GO
IF OBJECT_ID(N'[dbo].[FK_CarsToView_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarsToView] DROP CONSTRAINT [FK_CarsToView_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_CarUserComments_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarUserComments] DROP CONSTRAINT [FK_CarUserComments_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_CarUserComments_CarUserComments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarUserComments] DROP CONSTRAINT [FK_CarUserComments_CarUserComments];
GO
IF OBJECT_ID(N'[dbo].[FK_CarUserComments_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarUserComments] DROP CONSTRAINT [FK_CarUserComments_User];
GO
IF OBJECT_ID(N'[dbo].[FK_CarWheels_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarWheels] DROP CONSTRAINT [FK_CarWheels_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_Category_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Category] DROP CONSTRAINT [FK_Category_Category];
GO
IF OBJECT_ID(N'[dbo].[FK_ContentPresentation_Contents]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentPresentation] DROP CONSTRAINT [FK_ContentPresentation_Contents];
GO
IF OBJECT_ID(N'[dbo].[FK_Contents_ContentsCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contents] DROP CONSTRAINT [FK_Contents_ContentsCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_ContentsCategory_ContentsCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentsCategory] DROP CONSTRAINT [FK_ContentsCategory_ContentsCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_ContentUserComments_Contents]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentUserComments] DROP CONSTRAINT [FK_ContentUserComments_Contents];
GO
IF OBJECT_ID(N'[dbo].[FK_ContentUserComments_ContentUserComments2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentUserComments] DROP CONSTRAINT [FK_ContentUserComments_ContentUserComments2];
GO
IF OBJECT_ID(N'[dbo].[FK_ContentUserComments_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentUserComments] DROP CONSTRAINT [FK_ContentUserComments_User];
GO
IF OBJECT_ID(N'[dbo].[FK_ContetComments_Contents]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContetComments] DROP CONSTRAINT [FK_ContetComments_Contents];
GO
IF OBJECT_ID(N'[dbo].[FK_ContetComments_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContetComments] DROP CONSTRAINT [FK_ContetComments_User];
GO
IF OBJECT_ID(N'[dbo].[FK_DetailedBrakeSystem_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetailedBrakeSystem] DROP CONSTRAINT [FK_DetailedBrakeSystem_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_FuelConsumption_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FuelConsumption] DROP CONSTRAINT [FK_FuelConsumption_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_GlassAndMirrors_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GlassAndMirrors] DROP CONSTRAINT [FK_GlassAndMirrors_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_HomePageMenu_HomePageMenu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HomePageMenu] DROP CONSTRAINT [FK_HomePageMenu_HomePageMenu];
GO
IF OBJECT_ID(N'[dbo].[FK_Manufacture_Country]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Manufacture] DROP CONSTRAINT [FK_Manufacture_Country];
GO
IF OBJECT_ID(N'[dbo].[FK_Person_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Person] DROP CONSTRAINT [FK_Person_User];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonCarDetail_PersonCars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonCarDetail] DROP CONSTRAINT [FK_PersonCarDetail_PersonCars];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonCars_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonCars] DROP CONSTRAINT [FK_PersonCars_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonCars_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonCars] DROP CONSTRAINT [FK_PersonCars_User];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonProduct_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonProduct] DROP CONSTRAINT [FK_PersonProduct_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonProduct_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonProduct] DROP CONSTRAINT [FK_PersonProduct_User];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonProductEntity_PersonProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonProductEntity] DROP CONSTRAINT [FK_PersonProductEntity_PersonProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonServices_AutoService]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonServices] DROP CONSTRAINT [FK_PersonServices_AutoService];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonServices_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonServices] DROP CONSTRAINT [FK_PersonServices_User];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonServicesPack_AutoServicePack]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonServicesPack] DROP CONSTRAINT [FK_PersonServicesPack_AutoServicePack];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonServicesPack_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonServicesPack] DROP CONSTRAINT [FK_PersonServicesPack_User];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonServicesUseRequest_AutoService]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonServicesUseRequest] DROP CONSTRAINT [FK_PersonServicesUseRequest_AutoService];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonServicesUseRequest_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonServicesUseRequest] DROP CONSTRAINT [FK_PersonServicesUseRequest_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_CarBrand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_CarBrand];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_Category];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_Company]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_Company];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_Country]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_Country];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_Manufacture]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_Manufacture];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_ProductReview]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_ProductReview];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductCars_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductCars] DROP CONSTRAINT [FK_ProductCars_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductCars_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductCars] DROP CONSTRAINT [FK_ProductCars_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductComments_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductComments] DROP CONSTRAINT [FK_ProductComments_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductComments_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductComments] DROP CONSTRAINT [FK_ProductComments_User];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductDiscount_AutoService]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductDiscount] DROP CONSTRAINT [FK_ProductDiscount_AutoService];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductDiscount_AutoServicePack]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductDiscount] DROP CONSTRAINT [FK_ProductDiscount_AutoServicePack];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductDiscount_Discount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductDiscount] DROP CONSTRAINT [FK_ProductDiscount_Discount];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductDiscount_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductDiscount] DROP CONSTRAINT [FK_ProductDiscount_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductInService_AutoService]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductInService] DROP CONSTRAINT [FK_ProductInService_AutoService];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductInService_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductInService] DROP CONSTRAINT [FK_ProductInService_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductPrice_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductPrice] DROP CONSTRAINT [FK_ProductPrice_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductQnA_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductQnA] DROP CONSTRAINT [FK_ProductQnA_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductQnA_ProductQnA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductQnA] DROP CONSTRAINT [FK_ProductQnA_ProductQnA];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductServicePackUse_PersonServicesPack]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductServicePackUse] DROP CONSTRAINT [FK_ProductServicePackUse_PersonServicesPack];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductServiceUse_PersonServices]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductServiceUse] DROP CONSTRAINT [FK_ProductServiceUse_PersonServices];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductStore_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductStore] DROP CONSTRAINT [FK_ProductStore_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductToView_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductToView] DROP CONSTRAINT [FK_ProductToView_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductUserComments_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductUserComments] DROP CONSTRAINT [FK_ProductUserComments_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductUserComments_ProductUserComments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductUserComments] DROP CONSTRAINT [FK_ProductUserComments_ProductUserComments];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductUserComments_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductUserComments] DROP CONSTRAINT [FK_ProductUserComments_User];
GO
IF OBJECT_ID(N'[dbo].[FK_RootCarUserComments_Contents]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RootCarUserComments] DROP CONSTRAINT [FK_RootCarUserComments_Contents];
GO
IF OBJECT_ID(N'[dbo].[FK_RootCarUserComments_RootCarUserComments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RootCarUserComments] DROP CONSTRAINT [FK_RootCarUserComments_RootCarUserComments];
GO
IF OBJECT_ID(N'[dbo].[FK_RootCarUserComments_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RootCarUserComments] DROP CONSTRAINT [FK_RootCarUserComments_User];
GO
IF OBJECT_ID(N'[dbo].[FK_SecuritySystems_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SecuritySystems] DROP CONSTRAINT [FK_SecuritySystems_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_ServicesCategory_ServicesCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServicesCategory] DROP CONSTRAINT [FK_ServicesCategory_ServicesCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_ServicesPackToView_AutoServicePack]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServicesPackToView] DROP CONSTRAINT [FK_ServicesPackToView_AutoServicePack];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceToView_AutoService]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceToView] DROP CONSTRAINT [FK_ServiceToView_AutoService];
GO
IF OBJECT_ID(N'[dbo].[FK_SteeringSystem_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SteeringSystem] DROP CONSTRAINT [FK_SteeringSystem_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_TimeOfDay_DaysOfWeek]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TimeOfDay] DROP CONSTRAINT [FK_TimeOfDay_DaysOfWeek];
GO
IF OBJECT_ID(N'[dbo].[FK_TodaysSpecial_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TodaysSpecial] DROP CONSTRAINT [FK_TodaysSpecial_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_TroubleShootingCars_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TroubleShootingCars] DROP CONSTRAINT [FK_TroubleShootingCars_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_TroubleShootingCars_Troubleshooting]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TroubleShootingCars] DROP CONSTRAINT [FK_TroubleShootingCars_Troubleshooting];
GO
IF OBJECT_ID(N'[dbo].[FK_TroubleshootingProducts_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TroubleshootingProducts] DROP CONSTRAINT [FK_TroubleshootingProducts_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_TroubleshootingProducts_Troubleshooting]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TroubleshootingProducts] DROP CONSTRAINT [FK_TroubleshootingProducts_Troubleshooting];
GO
IF OBJECT_ID(N'[dbo].[FK_User_UserRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_UserRole];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AirConditioningSystem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AirConditioningSystem];
GO
IF OBJECT_ID(N'[dbo].[AirConditioningSystemDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AirConditioningSystemDetail];
GO
IF OBJECT_ID(N'[dbo].[AutoService]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AutoService];
GO
IF OBJECT_ID(N'[dbo].[AutoServiceCars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AutoServiceCars];
GO
IF OBJECT_ID(N'[dbo].[AutoServicePack]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AutoServicePack];
GO
IF OBJECT_ID(N'[dbo].[AutoServicePackUserComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AutoServicePackUserComments];
GO
IF OBJECT_ID(N'[dbo].[AutoServices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AutoServices];
GO
IF OBJECT_ID(N'[dbo].[AutoServicesUserComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AutoServicesUserComments];
GO
IF OBJECT_ID(N'[dbo].[BasketItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BasketItems];
GO
IF OBJECT_ID(N'[dbo].[Baskets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Baskets];
GO
IF OBJECT_ID(N'[dbo].[BrakeSystem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BrakeSystem];
GO
IF OBJECT_ID(N'[dbo].[CarAirbags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarAirbags];
GO
IF OBJECT_ID(N'[dbo].[CarAudioSystem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarAudioSystem];
GO
IF OBJECT_ID(N'[dbo].[CarBrand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarBrand];
GO
IF OBJECT_ID(N'[dbo].[CarComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarComments];
GO
IF OBJECT_ID(N'[dbo].[CarDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarDetails];
GO
IF OBJECT_ID(N'[dbo].[CarEngine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarEngine];
GO
IF OBJECT_ID(N'[dbo].[CarGearBox]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarGearBox];
GO
IF OBJECT_ID(N'[dbo].[CarLightingSystem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarLightingSystem];
GO
IF OBJECT_ID(N'[dbo].[CarModel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarModel];
GO
IF OBJECT_ID(N'[dbo].[CarPhysicalDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarPhysicalDetails];
GO
IF OBJECT_ID(N'[dbo].[CarPrice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarPrice];
GO
IF OBJECT_ID(N'[dbo].[Cars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cars];
GO
IF OBJECT_ID(N'[dbo].[CarSeatOptions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarSeatOptions];
GO
IF OBJECT_ID(N'[dbo].[CarSensorsSystem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarSensorsSystem];
GO
IF OBJECT_ID(N'[dbo].[CarsInSameClass]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarsInSameClass];
GO
IF OBJECT_ID(N'[dbo].[CarsPro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarsPro];
GO
IF OBJECT_ID(N'[dbo].[CarsQnA]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarsQnA];
GO
IF OBJECT_ID(N'[dbo].[CarsReview]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarsReview];
GO
IF OBJECT_ID(N'[dbo].[CarsReviewPoint]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarsReviewPoint];
GO
IF OBJECT_ID(N'[dbo].[CarsToView]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarsToView];
GO
IF OBJECT_ID(N'[dbo].[CarUserComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarUserComments];
GO
IF OBJECT_ID(N'[dbo].[CarWheels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarWheels];
GO
IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[Company]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Company];
GO
IF OBJECT_ID(N'[dbo].[ContactUsMessages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactUsMessages];
GO
IF OBJECT_ID(N'[dbo].[ContentPresentation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContentPresentation];
GO
IF OBJECT_ID(N'[dbo].[Contents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contents];
GO
IF OBJECT_ID(N'[dbo].[ContentsCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContentsCategory];
GO
IF OBJECT_ID(N'[dbo].[ContentUserComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContentUserComments];
GO
IF OBJECT_ID(N'[dbo].[ContetComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContetComments];
GO
IF OBJECT_ID(N'[dbo].[Country]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Country];
GO
IF OBJECT_ID(N'[dbo].[DaysOfWeek]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DaysOfWeek];
GO
IF OBJECT_ID(N'[dbo].[DetailedBrakeSystem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetailedBrakeSystem];
GO
IF OBJECT_ID(N'[dbo].[Discount]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Discount];
GO
IF OBJECT_ID(N'[dbo].[FuelConsumption]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FuelConsumption];
GO
IF OBJECT_ID(N'[dbo].[GlassAndMirrors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GlassAndMirrors];
GO
IF OBJECT_ID(N'[dbo].[HomePageMenu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HomePageMenu];
GO
IF OBJECT_ID(N'[dbo].[Manufacture]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Manufacture];
GO
IF OBJECT_ID(N'[dbo].[MarketingMails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MarketingMails];
GO
IF OBJECT_ID(N'[dbo].[NewLatterEmails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NewLatterEmails];
GO
IF OBJECT_ID(N'[dbo].[Person]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Person];
GO
IF OBJECT_ID(N'[dbo].[PersonCarDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonCarDetail];
GO
IF OBJECT_ID(N'[dbo].[PersonCars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonCars];
GO
IF OBJECT_ID(N'[dbo].[PersonProduct]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonProduct];
GO
IF OBJECT_ID(N'[dbo].[PersonProductEntity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonProductEntity];
GO
IF OBJECT_ID(N'[dbo].[PersonServices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonServices];
GO
IF OBJECT_ID(N'[dbo].[PersonServicesPack]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonServicesPack];
GO
IF OBJECT_ID(N'[dbo].[PersonServicesUseRequest]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonServicesUseRequest];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[ProductCars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductCars];
GO
IF OBJECT_ID(N'[dbo].[ProductComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductComments];
GO
IF OBJECT_ID(N'[dbo].[ProductDiscount]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductDiscount];
GO
IF OBJECT_ID(N'[dbo].[ProductInService]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductInService];
GO
IF OBJECT_ID(N'[dbo].[ProductPrice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductPrice];
GO
IF OBJECT_ID(N'[dbo].[ProductQnA]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductQnA];
GO
IF OBJECT_ID(N'[dbo].[ProductReview]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductReview];
GO
IF OBJECT_ID(N'[dbo].[ProductServicePackUse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductServicePackUse];
GO
IF OBJECT_ID(N'[dbo].[ProductServiceUse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductServiceUse];
GO
IF OBJECT_ID(N'[dbo].[ProductsOrServicesDeliveryTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductsOrServicesDeliveryTypes];
GO
IF OBJECT_ID(N'[dbo].[ProductStore]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductStore];
GO
IF OBJECT_ID(N'[dbo].[ProductToView]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductToView];
GO
IF OBJECT_ID(N'[dbo].[ProductUserComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductUserComments];
GO
IF OBJECT_ID(N'[dbo].[RootCarUserComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RootCarUserComments];
GO
IF OBJECT_ID(N'[dbo].[SecuritySystems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SecuritySystems];
GO
IF OBJECT_ID(N'[dbo].[ServicesCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServicesCategory];
GO
IF OBJECT_ID(N'[dbo].[ServicesPackToView]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServicesPackToView];
GO
IF OBJECT_ID(N'[dbo].[ServiceToView]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceToView];
GO
IF OBJECT_ID(N'[dbo].[SlideShows]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SlideShows];
GO
IF OBJECT_ID(N'[dbo].[SteeringSystem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SteeringSystem];
GO
IF OBJECT_ID(N'[dbo].[TimeOfDay]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimeOfDay];
GO
IF OBJECT_ID(N'[dbo].[TodaysSpecial]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TodaysSpecial];
GO
IF OBJECT_ID(N'[dbo].[Troubleshooting]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Troubleshooting];
GO
IF OBJECT_ID(N'[dbo].[TroubleShootingCars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TroubleShootingCars];
GO
IF OBJECT_ID(N'[dbo].[TroubleshootingProducts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TroubleshootingProducts];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[UserRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRole];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AirConditioningSystems'
CREATE TABLE [dbo].[AirConditioningSystems] (
    [AirConditioningSystemId] int IDENTITY(1,1) NOT NULL,
    [CarId] int  NULL,
    [AirConditioningType] nvarchar(50)  NULL,
    [Details] nvarchar(max)  NULL
);
GO

-- Creating table 'AirConditioningSystemDetails'
CREATE TABLE [dbo].[AirConditioningSystemDetails] (
    [AirConditioningSystemDetailId] int IDENTITY(1,1) NOT NULL,
    [AirConditioningSystemDetailSubject] nvarchar(50)  NULL,
    [AirConditioningSystemDetail1] nvarchar(max)  NULL,
    [CarsId] int  NULL
);
GO

-- Creating table 'AutoServices'
CREATE TABLE [dbo].[AutoServices] (
    [AutoServiceId] int IDENTITY(1,1) NOT NULL,
    [AutoServiceName] nvarchar(50)  NULL,
    [HasCarId] bit  NULL,
    [HasProduct] bit  NULL,
    [Price] nvarchar(50)  NULL,
    [ServicesCategoryId] int  NULL,
    [AutoServiceDescription] nvarchar(max)  NULL
);
GO

-- Creating table 'AutoServiceCars'
CREATE TABLE [dbo].[AutoServiceCars] (
    [AutoServiceCarsId] bigint IDENTITY(1,1) NOT NULL,
    [CarsId] int  NULL,
    [AutoServiceId] int  NULL
);
GO

-- Creating table 'AutoServicePacks'
CREATE TABLE [dbo].[AutoServicePacks] (
    [AutoServicePackId] int IDENTITY(1,1) NOT NULL,
    [AutoServicePackName] nvarchar(50)  NULL,
    [PackPrice] nvarchar(50)  NULL,
    [Details] nvarchar(max)  NULL
);
GO

-- Creating table 'AutoServicePackUserComments'
CREATE TABLE [dbo].[AutoServicePackUserComments] (
    [AutoServicePackUserCommentsId] int IDENTITY(1,1) NOT NULL,
    [AutoServicePackID] int  NULL,
    [UserId] int  NULL,
    [Comment] nvarchar(max)  NULL,
    [DateTime] datetime  NULL,
    [rootAutoServicePackUserCommentsId] int  NULL
);
GO

-- Creating table 'AutoServices1'
CREATE TABLE [dbo].[AutoServices1] (
    [AutoServicesId] int IDENTITY(1,1) NOT NULL,
    [AutoServiceId] int  NULL,
    [AutoServicePackId] int  NULL
);
GO

-- Creating table 'AutoServicesUserComments'
CREATE TABLE [dbo].[AutoServicesUserComments] (
    [AutoServicesUserCommentsId] int IDENTITY(1,1) NOT NULL,
    [AutoServicesId] int  NULL,
    [UserId] int  NULL,
    [Comment] nvarchar(max)  NULL,
    [DateTime] datetime  NULL,
    [RootAutoServicesUserCommentsId] int  NULL
);
GO

-- Creating table 'BasketItems'
CREATE TABLE [dbo].[BasketItems] (
    [BasketItemId] int IDENTITY(1,1) NOT NULL,
    [BasketId] int  NULL,
    [Id] int  NULL,
    [Type] tinyint  NULL,
    [Count] int  NULL,
    [ProductEachPrice] nvarchar(50)  NULL,
    [ProductEachPaidPrice] nvarchar(50)  NULL,
    [ToatoalPaidPrice] nvarchar(250)  NULL,
    [PriceFlag] tinyint  NULL,
    [DiscountId] int  NULL
);
GO

-- Creating table 'Baskets'
CREATE TABLE [dbo].[Baskets] (
    [BasketId] int IDENTITY(1,1) NOT NULL,
    [State] tinyint  NULL,
    [FinishDate] datetime  NULL,
    [DelivaryDate] datetime  NULL,
    [PaymentType] tinyint  NULL,
    [DelivaryTypeId] int  NULL,
    [UserId] int  NULL,
    [BankCode] nvarchar(255)  NULL,
    [LocalCode] nvarchar(50)  NULL,
    [DiscountId] int  NULL,
    [ReciverFullname] nvarchar(255)  NULL,
    [ReciverTell] nvarchar(50)  NULL,
    [ReciverMobile] nvarchar(50)  NULL,
    [ReciverAddress] nvarchar(max)  NULL,
    [ReciverWorkplace] nvarchar(max)  NULL,
    [TimeOfDayId] int  NULL
);
GO

-- Creating table 'BrakeSystems'
CREATE TABLE [dbo].[BrakeSystems] (
    [BrakeSystemId] int IDENTITY(1,1) NOT NULL,
    [CarId] int  NULL,
    [FrontBrakeSystem] nvarchar(50)  NULL,
    [RearBrakeSystem] nvarchar(50)  NULL,
    [OtherSystem] nvarchar(max)  NULL,
    [HandBrakeSystem] nvarchar(50)  NULL,
    [Details] nvarchar(max)  NULL
);
GO

-- Creating table 'CarAirbags'
CREATE TABLE [dbo].[CarAirbags] (
    [CarAirbagsId] int IDENTITY(1,1) NOT NULL,
    [DriverAirBag] bit  NULL,
    [FrontAirBag] bit  NULL,
    [AirBag] bit  NULL,
    [AirBagEntity] int  NULL,
    [Details] nvarchar(max)  NULL,
    [CarsId] int  NULL
);
GO

-- Creating table 'CarAudioSystems'
CREATE TABLE [dbo].[CarAudioSystems] (
    [CarAudioSystemId] int IDENTITY(1,1) NOT NULL,
    [AudioSystemType] nvarchar(50)  NULL,
    [AudioSystemBrand] nvarchar(50)  NULL,
    [HasMonitor] bit  NULL,
    [RearSeatsMonitor] bit  NULL,
    [RearGearCamera] bit  NULL,
    [FrontCamera] bit  NULL,
    [RearStereo] nvarchar(50)  NULL,
    [FrontStereo] nvarchar(50)  NULL,
    [Subwoofer] nvarchar(50)  NULL,
    [Amplifire] nvarchar(50)  NULL,
    [HasGps] bit  NULL,
    [Details] nvarchar(max)  NULL,
    [CarsId] int  NOT NULL
);
GO

-- Creating table 'CarBrands'
CREATE TABLE [dbo].[CarBrands] (
    [CarBrandId] int IDENTITY(1,1) NOT NULL,
    [CarBrandName] nvarchar(150)  NULL,
    [CarBrandHistory] nvarchar(max)  NULL
);
GO

-- Creating table 'CarComments'
CREATE TABLE [dbo].[CarComments] (
    [CarCommentsId] int IDENTITY(1,1) NOT NULL,
    [CarsId] int  NULL,
    [Fullname] nvarchar(255)  NULL,
    [Email] nvarchar(255)  NULL,
    [Comment] nvarchar(max)  NULL,
    [UserId] int  NULL,
    [canshow] bit  NULL,
    [datetime] datetime  NULL,
    [Response] nvarchar(max)  NULL,
    [ResponseDateTime] datetime  NULL
);
GO

-- Creating table 'CarDetails'
CREATE TABLE [dbo].[CarDetails] (
    [CarDetailsId] int IDENTITY(1,1) NOT NULL,
    [CarsId] int  NULL,
    [OilChangeDate] int  NULL,
    [OilChangeMilage] int  NULL,
    [OilFiltersChangeDate] int  NULL,
    [OilFilterChangeMilage] int  NULL,
    [GearBoxOilChangeDate] int  NULL,
    [GearBoxOilChangeMilage] int  NULL,
    [AirFilterChangeDate] int  NULL,
    [AirFilterChangeMilage] int  NULL,
    [TiresChangeDate] int  NULL,
    [TiresChangeMilage] int  NULL,
    [TimingbeltChangeDate] int  NULL,
    [TimingbeltChangeMilage] int  NULL,
    [OtherBeltsChangeDate] int  NULL,
    [OtherBeltsChangeMilage] int  NULL,
    [FrontBrakePadsChangeDate] int  NULL,
    [FrontBrakePadsChangeMilage] int  NULL,
    [RearBreakePadsChangeDate] int  NULL,
    [RearBrakePadsChangeMilage] int  NULL
);
GO

-- Creating table 'CarEngines'
CREATE TABLE [dbo].[CarEngines] (
    [CarEngineId] int IDENTITY(1,1) NOT NULL,
    [EngineType] nvarchar(50)  NULL,
    [EngineCylinderNumber] int  NULL,
    [EnginePowerHpRpm] int  NULL,
    [EngineTorque] int  NULL,
    [EnginePowerHpTon] int  NULL,
    [EnginePowerHpLitr] int  NULL,
    [EngineMaxSpeed] int  NULL,
    [EngineZeroToH] float  NULL,
    [EngineDescription] nvarchar(max)  NULL,
    [CarsId] int  NULL,
    [EngineSize] int  NULL,
    [EngineFuel] nvarchar(50)  NULL
);
GO

-- Creating table 'CarGearBoxes'
CREATE TABLE [dbo].[CarGearBoxes] (
    [CarGearBoxId] int IDENTITY(1,1) NOT NULL,
    [GearBoxCode] nvarchar(50)  NULL,
    [GearBoxType] nvarchar(50)  NULL,
    [GearBoxCanBeManual] bit  NULL,
    [GearBoxShiftNumber] int  NULL,
    [GearBoxAxel] nvarchar(50)  NULL,
    [HasTransferCase] bit  NULL,
    [GearBoxDiffrentionalLock] bit  NULL,
    [GearBoxWdType] nvarchar(50)  NULL,
    [GearBoxDescription] nvarchar(max)  NULL,
    [CarsId] int  NULL,
    [GearBoxShifter] bit  NULL
);
GO

-- Creating table 'CarLightingSystems'
CREATE TABLE [dbo].[CarLightingSystems] (
    [CarLightingSystemId] int IDENTITY(1,1) NOT NULL,
    [FrontLights] nvarchar(50)  NULL,
    [RearLights] nvarchar(50)  NULL,
    [DayLight] bit  NULL,
    [SideMirrorLight] bit  NULL,
    [FonrAntiFog] bit  NULL,
    [RearAntiFog] bit  NULL,
    [ReadingLamp] bit  NULL,
    [Deailts] nvarchar(max)  NULL,
    [CarsId] int  NULL,
    [ThirdLightStop] bit  NULL
);
GO

-- Creating table 'CarModels'
CREATE TABLE [dbo].[CarModels] (
    [CarModelId] int IDENTITY(1,1) NOT NULL,
    [CarModelName] nvarchar(150)  NULL,
    [CarBrandId] int  NULL
);
GO

-- Creating table 'CarPhysicalDetails'
CREATE TABLE [dbo].[CarPhysicalDetails] (
    [CarPhysicalDetailsId] int IDENTITY(1,1) NOT NULL,
    [CarLength] int  NULL,
    [Carwidth] int  NULL,
    [CarHeight] int  NULL,
    [CarTrack] int  NULL,
    [CarWheelBase] int  NULL,
    [CarPureWeight] int  NULL,
    [CarTankSize] int  NULL,
    [Details] nvarchar(max)  NULL,
    [CarId] int  NULL
);
GO

-- Creating table 'CarPrices'
CREATE TABLE [dbo].[CarPrices] (
    [CarPriceId] int IDENTITY(1,1) NOT NULL,
    [CarsId] int  NULL,
    [Price] float  NULL,
    [Date] datetime  NULL
);
GO

-- Creating table 'Cars'
CREATE TABLE [dbo].[Cars] (
    [CarsId] int IDENTITY(1,1) NOT NULL,
    [CarModelId] int  NULL,
    [CarsClass] nvarchar(50)  NULL,
    [CarsUserScore] float  NULL,
    [CarsClinicScore] float  NULL,
    [Price] int  NULL,
    [CarsPicsId] int  NULL,
    [CarsVideoURL] nvarchar(50)  NULL,
    [CarsDescription] nvarchar(max)  NULL,
    [CarClassType] nvarchar(50)  NULL,
    [CarCategory] nvarchar(50)  NULL,
    [CarUsage] nvarchar(100)  NULL,
    [CarYearModel] int  NULL,
    [CarBodyType] nvarchar(50)  NULL,
    [CountryId] int  NULL
);
GO

-- Creating table 'CarSeatOptions'
CREATE TABLE [dbo].[CarSeatOptions] (
    [CarSeatOptionsId] int IDENTITY(1,1) NOT NULL,
    [LongitudinalDisplacement] bit  NULL,
    [BezelSet] bit  NULL,
    [SeatWarmer] bit  NULL,
    [SeatMassage] bit  NULL,
    [HasMemory] bit  NULL,
    [Details] nvarchar(max)  NULL,
    [CarsId] int  NOT NULL
);
GO

-- Creating table 'CarSensorsSystems'
CREATE TABLE [dbo].[CarSensorsSystems] (
    [CarSensorsSystemId] int IDENTITY(1,1) NOT NULL,
    [DayLightSensor] bit  NULL,
    [RainSensor] bit  NULL,
    [RearGearSensor] bit  NULL,
    [ParkSensor] bit  NULL,
    [NavigateSensor] bit  NULL,
    [CruiseControl] bit  NULL,
    [RearGearCamera] bit  NULL,
    [Details] nvarchar(max)  NULL,
    [CarsId] int  NULL
);
GO

-- Creating table 'CarsInSameClasses'
CREATE TABLE [dbo].[CarsInSameClasses] (
    [CarsSameId] int IDENTITY(1,1) NOT NULL,
    [CarsId] int  NULL,
    [CarsSameClassId] int  NULL
);
GO

-- Creating table 'CarsProes'
CREATE TABLE [dbo].[CarsProes] (
    [CarPsId] int IDENTITY(1,1) NOT NULL,
    [CarsId] int  NULL,
    [CarsProOrCro] bit  NULL,
    [CarProCro] nvarchar(50)  NULL
);
GO

-- Creating table 'CarsQnAs'
CREATE TABLE [dbo].[CarsQnAs] (
    [CarsQnAId] int IDENTITY(1,1) NOT NULL,
    [CarsId] int  NULL,
    [QuestionType] nvarchar(150)  NULL,
    [Question] nvarchar(max)  NULL,
    [QuestionId] int  NULL
);
GO

-- Creating table 'CarsReviews'
CREATE TABLE [dbo].[CarsReviews] (
    [CarsReviewId] int IDENTITY(1,1) NOT NULL,
    [CarsId] int  NULL,
    [Review] nvarchar(max)  NULL,
    [CarScore] float  NULL,
    [Beauty] float  NULL,
    [WorthBuying] float  NULL,
    [Quality] float  NULL,
    [Services] float  NULL
);
GO

-- Creating table 'CarsReviewPoints'
CREATE TABLE [dbo].[CarsReviewPoints] (
    [CarsReviewPointId] int IDENTITY(1,1) NOT NULL,
    [CarsReviewSubject] nvarchar(50)  NULL,
    [CarsReview] nvarchar(max)  NULL,
    [CarsId] int  NULL,
    [LastPointId] int  NULL
);
GO

-- Creating table 'CarsToViews'
CREATE TABLE [dbo].[CarsToViews] (
    [CarsToViewId] int IDENTITY(1,1) NOT NULL,
    [CarsId] int  NULL,
    [View] int  NULL,
    [Favorite] int  NULL
);
GO

-- Creating table 'CarUserComments'
CREATE TABLE [dbo].[CarUserComments] (
    [CarUserCommentsId] int IDENTITY(1,1) NOT NULL,
    [CarId] int  NULL,
    [UserId] int  NULL,
    [Comment] nvarchar(max)  NULL,
    [DateTime] datetime  NULL,
    [RootCarUserCommentsId] int  NULL,
    [CarRating] tinyint  NULL,
    [Beautifully] tinyint  NULL,
    [Worthly] tinyint  NULL,
    [Quality] tinyint  NULL,
    [Services] tinyint  NULL
);
GO

-- Creating table 'CarWheels'
CREATE TABLE [dbo].[CarWheels] (
    [CarWheelsId] int IDENTITY(1,1) NOT NULL,
    [CarsId] int  NULL,
    [TireType] nvarchar(50)  NULL,
    [RingStandardSize] int  NULL,
    [TireSpec] nvarchar(50)  NULL,
    [RingType] nvarchar(50)  NULL,
    [RingModel] nvarchar(50)  NULL,
    [AutoInflated] bit  NULL,
    [Details] nvarchar(max)  NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [CategoryId] int IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(50)  NULL,
    [ParentCategoryId] int  NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Companies'
CREATE TABLE [dbo].[Companies] (
    [CompanyId] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(50)  NULL,
    [CompanyAddress] nvarchar(max)  NULL
);
GO

-- Creating table 'ContactUsMessages'
CREATE TABLE [dbo].[ContactUsMessages] (
    [MessagID] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(255)  NULL,
    [Subject] nvarchar(255)  NULL,
    [Email] nvarchar(255)  NULL,
    [Message] nvarchar(max)  NULL,
    [Date] datetime  NULL,
    [Seen] datetime  NULL
);
GO

-- Creating table 'ContentPresentations'
CREATE TABLE [dbo].[ContentPresentations] (
    [ContentId] int  NOT NULL,
    [ShowCount] int  NULL,
    [Like] int  NULL,
    [Dislike] int  NULL
);
GO

-- Creating table 'Contents'
CREATE TABLE [dbo].[Contents] (
    [ContenstId] int IDENTITY(1,1) NOT NULL,
    [ContentsCategoryId] int  NULL,
    [ContentSubject] nvarchar(150)  NULL,
    [ContentDescribe] nvarchar(max)  NULL,
    [ContentText] nvarchar(max)  NULL,
    [VideoUrl] nvarchar(255)  NULL,
    [ContentType] nchar(10)  NULL,
    [tags] nvarchar(350)  NULL,
    [Date] datetime  NULL,
    [LastUpdateDate] datetime  NULL
);
GO

-- Creating table 'ContentsCategories'
CREATE TABLE [dbo].[ContentsCategories] (
    [ContentsCategoryId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(255)  NULL,
    [Describe] nvarchar(max)  NULL,
    [ParentId] int  NULL
);
GO

-- Creating table 'ContentUserComments'
CREATE TABLE [dbo].[ContentUserComments] (
    [ContentUserCommentsId] int IDENTITY(1,1) NOT NULL,
    [ContenstId] int  NULL,
    [UserId] int  NULL,
    [Comment] nvarchar(max)  NULL,
    [DateTime] datetime  NULL,
    [RootContentUserCommentsId] int  NULL
);
GO

-- Creating table 'ContetComments'
CREATE TABLE [dbo].[ContetComments] (
    [ContentCommentsId] int IDENTITY(1,1) NOT NULL,
    [ContentsId] int  NULL,
    [FullName] nvarchar(255)  NULL,
    [Email] nvarchar(255)  NULL,
    [Comment] nvarchar(max)  NULL,
    [UserId] int  NULL,
    [Date] datetime  NULL
);
GO

-- Creating table 'Countries'
CREATE TABLE [dbo].[Countries] (
    [CountryId] int IDENTITY(1,1) NOT NULL,
    [CountryShortName] nvarchar(50)  NULL,
    [CountryLongName] nvarchar(max)  NULL
);
GO

-- Creating table 'DaysOfWeeks'
CREATE TABLE [dbo].[DaysOfWeeks] (
    [DaysOfWeekId] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NULL,
    [DayOfWeek] nvarchar(50)  NULL,
    [IsActive] bit  NULL
);
GO

-- Creating table 'DetailedBrakeSystems'
CREATE TABLE [dbo].[DetailedBrakeSystems] (
    [DetailedBrakeSystemId] int IDENTITY(1,1) NOT NULL,
    [DetailedName] nvarchar(50)  NULL,
    [HaveDetailed] bit  NULL,
    [CarId] int  NULL
);
GO

-- Creating table 'Discounts'
CREATE TABLE [dbo].[Discounts] (
    [DiscountId] int IDENTITY(1,1) NOT NULL,
    [DiscountCode] nvarchar(50)  NULL,
    [Discount1] nvarchar(50)  NULL
);
GO

-- Creating table 'FuelConsumptions'
CREATE TABLE [dbo].[FuelConsumptions] (
    [FuelConsumptionId] int IDENTITY(1,1) NOT NULL,
    [LphCity] float  NULL,
    [LphRoad] float  NULL,
    [LphMix] float  NULL,
    [Details] nvarchar(max)  NULL,
    [ReservedOne] nvarchar(50)  NULL,
    [ReservedTwo] nvarchar(50)  NULL,
    [ReservedThree] nvarchar(50)  NULL,
    [CarId] int  NULL
);
GO

-- Creating table 'GlassAndMirrors'
CREATE TABLE [dbo].[GlassAndMirrors] (
    [GlassAndMirrorsId] int IDENTITY(1,1) NOT NULL,
    [FrontWindscreens] nvarchar(50)  NULL,
    [RearWindscreens] nvarchar(50)  NULL,
    [SunRoof] bit  NULL,
    [PanaromaRoof] bit  NULL,
    [RearGlassWarmer] bit  NULL,
    [WindscreensWarmer] bit  NULL,
    [FrontGlassWarmer] bit  NULL,
    [SideMirrorSet] nvarchar(50)  NULL,
    [SideMirrorSystem] nvarchar(50)  NULL,
    [Details] nvarchar(max)  NULL,
    [CarsId] int  NULL
);
GO

-- Creating table 'HomePageMenus'
CREATE TABLE [dbo].[HomePageMenus] (
    [HomePageMenuId] int IDENTITY(1,1) NOT NULL,
    [Subject] nvarchar(255)  NULL,
    [Title] nvarchar(255)  NULL,
    [Target] nvarchar(max)  NULL,
    [RootHomePageMenuId] int  NULL
);
GO

-- Creating table 'Manufactures'
CREATE TABLE [dbo].[Manufactures] (
    [ManufactureId] int IDENTITY(1,1) NOT NULL,
    [ManufactureName] nvarchar(50)  NULL,
    [Address] nvarchar(max)  NULL,
    [ManufacturePhon] nvarchar(50)  NULL,
    [CountryId] int  NULL
);
GO

-- Creating table 'MarketingMails'
CREATE TABLE [dbo].[MarketingMails] (
    [MarketingMailId] int IDENTITY(1,1) NOT NULL,
    [Recivers] nvarchar(max)  NULL,
    [Subject] nvarchar(255)  NULL,
    [Body] nvarchar(max)  NULL,
    [DateTime] datetime  NULL
);
GO

-- Creating table 'NewLatterEmails'
CREATE TABLE [dbo].[NewLatterEmails] (
    [Email] nvarchar(255)  NOT NULL,
    [Datetime] datetime  NULL
);
GO

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [PersonId] int IDENTITY(1,1) NOT NULL,
    [PersonFirtstName] nvarchar(50)  NULL,
    [PersonLastName] nvarchar(50)  NULL,
    [PersonPhone] nvarchar(50)  NULL,
    [PersonMobile] nvarchar(50)  NULL,
    [PersonEmail] nvarchar(50)  NULL,
    [PersonAddressCity] nvarchar(50)  NULL,
    [PersonAddress] nvarchar(max)  NULL,
    [UserId] int  NULL
);
GO

-- Creating table 'PersonCarDetails'
CREATE TABLE [dbo].[PersonCarDetails] (
    [PersonCarDetailId] int IDENTITY(1,1) NOT NULL,
    [PersonCarId] int  NULL,
    [LastOilChange] datetime  NULL,
    [LastOilFiltersChange] datetime  NULL,
    [LastOilChangeMilage] int  NULL,
    [LastOilFilterChangeMilage] int  NULL,
    [LastGearBoxOilChange] datetime  NULL,
    [LastGearBoxOilChangeMilage] int  NULL,
    [LastAirFilterChange] datetime  NULL,
    [LastAirFilterChangeMilage] int  NULL,
    [LastTiresChange] datetime  NULL,
    [LastTiresChangeMilage] int  NULL,
    [LastTimingbeltChange] datetime  NULL,
    [LastTimingbeltChangeMilage] int  NULL,
    [LastOtherBeltsChange] datetime  NULL,
    [LastOtherBeltsChangeMilage] int  NULL,
    [LastFrontBrakePadsChange] datetime  NULL,
    [LastFrontBrakePadsChangeMilage] int  NULL,
    [LastRearBreakePadsChange] datetime  NULL,
    [LastRearBrakePadsChangeMilage] int  NULL
);
GO

-- Creating table 'PersonCars'
CREATE TABLE [dbo].[PersonCars] (
    [PersonCarsId] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NULL,
    [CarId] int  NULL,
    [CarMilage] int  NULL,
    [CarCreationDate] nvarchar(50)  NULL,
    [CarColor] nvarchar(50)  NULL,
    [CarPlate] nvarchar(50)  NULL,
    [CarPlateCityCode] int  NULL
);
GO

-- Creating table 'PersonProducts'
CREATE TABLE [dbo].[PersonProducts] (
    [PersonProductId] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NULL,
    [ProductId] int  NULL,
    [ProductCurrentEntity] int  NULL,
    [DateAdded] datetime  NULL
);
GO

-- Creating table 'PersonProductEntities'
CREATE TABLE [dbo].[PersonProductEntities] (
    [PersonProductEntityId] int IDENTITY(1,1) NOT NULL,
    [PersonProductId] int  NULL,
    [DateUsed] datetime  NULL,
    [EntityUsed] int  NULL
);
GO

-- Creating table 'PersonServices'
CREATE TABLE [dbo].[PersonServices] (
    [PersonServicesId] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NULL,
    [ServicesId] int  NULL,
    [ServicesCurrentEntity] int  NULL,
    [DateAdded] datetime  NULL
);
GO

-- Creating table 'PersonServicesPacks'
CREATE TABLE [dbo].[PersonServicesPacks] (
    [PersonServicesPackId] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NULL,
    [ServicesPackId] int  NULL,
    [ServicesPackCurrentEntity] int  NULL,
    [DateAdded] datetime  NULL
);
GO

-- Creating table 'PersonServicesUseRequests'
CREATE TABLE [dbo].[PersonServicesUseRequests] (
    [PersonServicesUseRequestId] int IDENTITY(1,1) NOT NULL,
    [RequestDateTime] datetime  NULL,
    [State] tinyint  NULL,
    [LastStateChangeDateTime] datetime  NULL,
    [UserId] int  NULL,
    [AutoServiceId] int  NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ProductId] int IDENTITY(1,1) NOT NULL,
    [ProductName] nvarchar(50)  NULL,
    [CarId] int  NULL,
    [CategoryId] int  NULL,
    [ProductHeight] float  NULL,
    [ProductWidth] float  NULL,
    [CompanyId] int  NULL,
    [ProductWeight] float  NULL,
    [ProductLength] float  NULL,
    [CountryId] int  NULL,
    [ManufactureId] int  NULL,
    [ProductSecription] nvarchar(max)  NULL,
    [PartNumber] int  NULL,
    [MetaTags] nvarchar(max)  NULL,
    [ProductRating] float  NULL,
    [ProductReviewId] int  NULL,
    [ProductQnAId] int  NULL,
    [DiscountId] int  NULL,
    [WithInstall] bit  NULL,
    [CarBrandId] int  NULL,
    [IsActive] bit  NULL
);
GO

-- Creating table 'ProductCars'
CREATE TABLE [dbo].[ProductCars] (
    [ProductCarsId] bigint IDENTITY(1,1) NOT NULL,
    [ProductId] int  NULL,
    [CarsId] int  NULL
);
GO

-- Creating table 'ProductComments'
CREATE TABLE [dbo].[ProductComments] (
    [ProductCommentId] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NULL,
    [Fullname] nvarchar(255)  NULL,
    [Email] nvarchar(255)  NULL,
    [Comment] nvarchar(max)  NULL,
    [UserId] int  NULL,
    [canshow] bit  NULL,
    [datetime] datetime  NULL
);
GO

-- Creating table 'ProductDiscounts'
CREATE TABLE [dbo].[ProductDiscounts] (
    [ProductDiscountId] int IDENTITY(1,1) NOT NULL,
    [ProductDiscount1] int  NULL,
    [ProductId] int  NULL,
    [DiscountId] int  NULL,
    [AutoServiceId] int  NULL,
    [AutoServicePackId] int  NULL
);
GO

-- Creating table 'ProductInServices'
CREATE TABLE [dbo].[ProductInServices] (
    [ProductInServiceId] bigint IDENTITY(1,1) NOT NULL,
    [ServiceId] int  NULL,
    [ProductId] int  NULL
);
GO

-- Creating table 'ProductPrices'
CREATE TABLE [dbo].[ProductPrices] (
    [ProductPriceId] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NULL,
    [ProductPrice1] int  NULL,
    [Date] datetime  NULL,
    [InstallPrice] int  NULL
);
GO

-- Creating table 'ProductQnAs'
CREATE TABLE [dbo].[ProductQnAs] (
    [ProductQnAId] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NULL,
    [QuestionType] nvarchar(150)  NULL,
    [Question] nvarchar(max)  NULL,
    [QuestionId] int  NULL
);
GO

-- Creating table 'ProductReviews'
CREATE TABLE [dbo].[ProductReviews] (
    [ProductReviewId] int IDENTITY(1,1) NOT NULL,
    [ProductReview1] nvarchar(max)  NULL
);
GO

-- Creating table 'ProductServicePackUses'
CREATE TABLE [dbo].[ProductServicePackUses] (
    [ProductServicePackUseId] int IDENTITY(1,1) NOT NULL,
    [PersonServicesPackId] int  NULL,
    [DateUsed] datetime  NULL,
    [EntityUsed] int  NULL
);
GO

-- Creating table 'ProductServiceUses'
CREATE TABLE [dbo].[ProductServiceUses] (
    [ProductServiceUseId] int IDENTITY(1,1) NOT NULL,
    [PersonServicesId] int  NULL,
    [DateUsed] datetime  NULL,
    [EntityUsed] int  NULL
);
GO

-- Creating table 'ProductsOrServicesDeliveryTypes'
CREATE TABLE [dbo].[ProductsOrServicesDeliveryTypes] (
    [DeliverTypeID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(255)  NULL,
    [Price] nvarchar(255)  NULL,
    [Hour] int  NULL
);
GO

-- Creating table 'ProductStores'
CREATE TABLE [dbo].[ProductStores] (
    [ProductStoreId] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NULL,
    [ProductEntity] int  NULL
);
GO

-- Creating table 'ProductToViews'
CREATE TABLE [dbo].[ProductToViews] (
    [ProdcutToViewId] int IDENTITY(1,1) NOT NULL,
    [Viewd] int  NULL,
    [Favorite] int  NULL,
    [ProductId] int  NULL
);
GO

-- Creating table 'ProductUserComments'
CREATE TABLE [dbo].[ProductUserComments] (
    [ProductUserCommentsId] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NULL,
    [UserId] int  NULL,
    [Comment] nvarchar(max)  NULL,
    [DateTime] datetime  NULL,
    [RootProductUserCommentsId] int  NULL
);
GO

-- Creating table 'RootCarUserComments'
CREATE TABLE [dbo].[RootCarUserComments] (
    [ContentUserCommentsId] int IDENTITY(1,1) NOT NULL,
    [ContentId] int  NULL,
    [UserId] int  NULL,
    [Comment] nvarchar(max)  NULL,
    [DateTime] datetime  NULL,
    [RootContentUserCommentsId] int  NULL
);
GO

-- Creating table 'SecuritySystems'
CREATE TABLE [dbo].[SecuritySystems] (
    [SecuritySystemsId] int IDENTITY(1,1) NOT NULL,
    [RemoteControl] bit  NULL,
    [BurglarAlarm] bit  NULL,
    [Alarm] bit  NULL,
    [Emo] bit  NULL,
    [KeylessDoor] bit  NULL,
    [KeylessStart] bit  NULL,
    [Details] nvarchar(max)  NULL,
    [CarId] int  NULL
);
GO

-- Creating table 'ServicesCategories'
CREATE TABLE [dbo].[ServicesCategories] (
    [ServicesCategoryId] int IDENTITY(1,1) NOT NULL,
    [ServicesCategoryName] nvarchar(50)  NULL,
    [ServicesParentCategoryId] int  NULL
);
GO

-- Creating table 'ServicesPackToViews'
CREATE TABLE [dbo].[ServicesPackToViews] (
    [ServicesPackToViewId] int IDENTITY(1,1) NOT NULL,
    [Viewd] int  NULL,
    [ServicesPackId] int  NULL,
    [Favorite] int  NULL
);
GO

-- Creating table 'ServiceToViews'
CREATE TABLE [dbo].[ServiceToViews] (
    [ServiceToViewId] int IDENTITY(1,1) NOT NULL,
    [Views] int  NULL,
    [ServiceId] int  NULL,
    [Favorite] int  NULL
);
GO

-- Creating table 'SlideShows'
CREATE TABLE [dbo].[SlideShows] (
    [SlideShowId] int IDENTITY(1,1) NOT NULL,
    [Subject] nvarchar(255)  NULL,
    [Describe] nvarchar(max)  NULL,
    [Image] nvarchar(255)  NULL,
    [Url] nvarchar(255)  NULL,
    [Type] tinyint  NULL
);
GO

-- Creating table 'SteeringSystems'
CREATE TABLE [dbo].[SteeringSystems] (
    [SteeringSystemId] int IDENTITY(1,1) NOT NULL,
    [SteeringSystemType] nvarchar(50)  NULL,
    [SteeringType] nvarchar(50)  NULL,
    [SteeringHeightAdjustble] bit  NULL,
    [SteeringControlKey] bit  NULL,
    [Details] nvarchar(max)  NULL,
    [CarId] int  NULL
);
GO

-- Creating table 'TimeOfDays'
CREATE TABLE [dbo].[TimeOfDays] (
    [TimeOfDayId] int IDENTITY(1,1) NOT NULL,
    [TimePeriod] nvarchar(50)  NULL,
    [DaysOfWeekId] int  NULL,
    [IsActive] bit  NULL
);
GO

-- Creating table 'TodaysSpecials'
CREATE TABLE [dbo].[TodaysSpecials] (
    [TodaysSpecialId] int IDENTITY(1,1) NOT NULL,
    [date] datetime  NULL,
    [ProductId] int  NULL,
    [Discount] int  NULL
);
GO

-- Creating table 'Troubleshootings'
CREATE TABLE [dbo].[Troubleshootings] (
    [TroubleshootingId] int IDENTITY(1,1) NOT NULL,
    [Subject] nvarchar(max)  NULL,
    [TroubleshootinParentId] int  NULL,
    [Type] tinyint  NULL,
    [Describe] nvarchar(max)  NULL,
    [Price] nvarchar(255)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [Uname] nvarchar(50)  NULL,
    [Upass] nvarchar(50)  NULL,
    [UserRoleId] int  NULL,
    [IsActive] bit  NULL,
    [ActiveRecoveryCode] nvarchar(50)  NULL,
    [ActiveORecovery] tinyint  NULL
);
GO

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [UserRoleId] int IDENTITY(1,1) NOT NULL,
    [UserRole1] nvarchar(50)  NULL
);
GO

-- Creating table 'TroubleShootingCars'
CREATE TABLE [dbo].[TroubleShootingCars] (
    [Cars_CarsId] int  NOT NULL,
    [Troubleshootings_TroubleshootingId] int  NOT NULL
);
GO

-- Creating table 'TroubleshootingProducts'
CREATE TABLE [dbo].[TroubleshootingProducts] (
    [Products_ProductId] int  NOT NULL,
    [Troubleshootings_TroubleshootingId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AirConditioningSystemId] in table 'AirConditioningSystems'
ALTER TABLE [dbo].[AirConditioningSystems]
ADD CONSTRAINT [PK_AirConditioningSystems]
    PRIMARY KEY CLUSTERED ([AirConditioningSystemId] ASC);
GO

-- Creating primary key on [AirConditioningSystemDetailId] in table 'AirConditioningSystemDetails'
ALTER TABLE [dbo].[AirConditioningSystemDetails]
ADD CONSTRAINT [PK_AirConditioningSystemDetails]
    PRIMARY KEY CLUSTERED ([AirConditioningSystemDetailId] ASC);
GO

-- Creating primary key on [AutoServiceId] in table 'AutoServices'
ALTER TABLE [dbo].[AutoServices]
ADD CONSTRAINT [PK_AutoServices]
    PRIMARY KEY CLUSTERED ([AutoServiceId] ASC);
GO

-- Creating primary key on [AutoServiceCarsId] in table 'AutoServiceCars'
ALTER TABLE [dbo].[AutoServiceCars]
ADD CONSTRAINT [PK_AutoServiceCars]
    PRIMARY KEY CLUSTERED ([AutoServiceCarsId] ASC);
GO

-- Creating primary key on [AutoServicePackId] in table 'AutoServicePacks'
ALTER TABLE [dbo].[AutoServicePacks]
ADD CONSTRAINT [PK_AutoServicePacks]
    PRIMARY KEY CLUSTERED ([AutoServicePackId] ASC);
GO

-- Creating primary key on [AutoServicePackUserCommentsId] in table 'AutoServicePackUserComments'
ALTER TABLE [dbo].[AutoServicePackUserComments]
ADD CONSTRAINT [PK_AutoServicePackUserComments]
    PRIMARY KEY CLUSTERED ([AutoServicePackUserCommentsId] ASC);
GO

-- Creating primary key on [AutoServicesId] in table 'AutoServices1'
ALTER TABLE [dbo].[AutoServices1]
ADD CONSTRAINT [PK_AutoServices1]
    PRIMARY KEY CLUSTERED ([AutoServicesId] ASC);
GO

-- Creating primary key on [AutoServicesUserCommentsId] in table 'AutoServicesUserComments'
ALTER TABLE [dbo].[AutoServicesUserComments]
ADD CONSTRAINT [PK_AutoServicesUserComments]
    PRIMARY KEY CLUSTERED ([AutoServicesUserCommentsId] ASC);
GO

-- Creating primary key on [BasketItemId] in table 'BasketItems'
ALTER TABLE [dbo].[BasketItems]
ADD CONSTRAINT [PK_BasketItems]
    PRIMARY KEY CLUSTERED ([BasketItemId] ASC);
GO

-- Creating primary key on [BasketId] in table 'Baskets'
ALTER TABLE [dbo].[Baskets]
ADD CONSTRAINT [PK_Baskets]
    PRIMARY KEY CLUSTERED ([BasketId] ASC);
GO

-- Creating primary key on [BrakeSystemId] in table 'BrakeSystems'
ALTER TABLE [dbo].[BrakeSystems]
ADD CONSTRAINT [PK_BrakeSystems]
    PRIMARY KEY CLUSTERED ([BrakeSystemId] ASC);
GO

-- Creating primary key on [CarAirbagsId] in table 'CarAirbags'
ALTER TABLE [dbo].[CarAirbags]
ADD CONSTRAINT [PK_CarAirbags]
    PRIMARY KEY CLUSTERED ([CarAirbagsId] ASC);
GO

-- Creating primary key on [CarAudioSystemId] in table 'CarAudioSystems'
ALTER TABLE [dbo].[CarAudioSystems]
ADD CONSTRAINT [PK_CarAudioSystems]
    PRIMARY KEY CLUSTERED ([CarAudioSystemId] ASC);
GO

-- Creating primary key on [CarBrandId] in table 'CarBrands'
ALTER TABLE [dbo].[CarBrands]
ADD CONSTRAINT [PK_CarBrands]
    PRIMARY KEY CLUSTERED ([CarBrandId] ASC);
GO

-- Creating primary key on [CarCommentsId] in table 'CarComments'
ALTER TABLE [dbo].[CarComments]
ADD CONSTRAINT [PK_CarComments]
    PRIMARY KEY CLUSTERED ([CarCommentsId] ASC);
GO

-- Creating primary key on [CarDetailsId] in table 'CarDetails'
ALTER TABLE [dbo].[CarDetails]
ADD CONSTRAINT [PK_CarDetails]
    PRIMARY KEY CLUSTERED ([CarDetailsId] ASC);
GO

-- Creating primary key on [CarEngineId] in table 'CarEngines'
ALTER TABLE [dbo].[CarEngines]
ADD CONSTRAINT [PK_CarEngines]
    PRIMARY KEY CLUSTERED ([CarEngineId] ASC);
GO

-- Creating primary key on [CarGearBoxId] in table 'CarGearBoxes'
ALTER TABLE [dbo].[CarGearBoxes]
ADD CONSTRAINT [PK_CarGearBoxes]
    PRIMARY KEY CLUSTERED ([CarGearBoxId] ASC);
GO

-- Creating primary key on [CarLightingSystemId] in table 'CarLightingSystems'
ALTER TABLE [dbo].[CarLightingSystems]
ADD CONSTRAINT [PK_CarLightingSystems]
    PRIMARY KEY CLUSTERED ([CarLightingSystemId] ASC);
GO

-- Creating primary key on [CarModelId] in table 'CarModels'
ALTER TABLE [dbo].[CarModels]
ADD CONSTRAINT [PK_CarModels]
    PRIMARY KEY CLUSTERED ([CarModelId] ASC);
GO

-- Creating primary key on [CarPhysicalDetailsId] in table 'CarPhysicalDetails'
ALTER TABLE [dbo].[CarPhysicalDetails]
ADD CONSTRAINT [PK_CarPhysicalDetails]
    PRIMARY KEY CLUSTERED ([CarPhysicalDetailsId] ASC);
GO

-- Creating primary key on [CarPriceId] in table 'CarPrices'
ALTER TABLE [dbo].[CarPrices]
ADD CONSTRAINT [PK_CarPrices]
    PRIMARY KEY CLUSTERED ([CarPriceId] ASC);
GO

-- Creating primary key on [CarsId] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [PK_Cars]
    PRIMARY KEY CLUSTERED ([CarsId] ASC);
GO

-- Creating primary key on [CarSeatOptionsId] in table 'CarSeatOptions'
ALTER TABLE [dbo].[CarSeatOptions]
ADD CONSTRAINT [PK_CarSeatOptions]
    PRIMARY KEY CLUSTERED ([CarSeatOptionsId] ASC);
GO

-- Creating primary key on [CarSensorsSystemId] in table 'CarSensorsSystems'
ALTER TABLE [dbo].[CarSensorsSystems]
ADD CONSTRAINT [PK_CarSensorsSystems]
    PRIMARY KEY CLUSTERED ([CarSensorsSystemId] ASC);
GO

-- Creating primary key on [CarsSameId] in table 'CarsInSameClasses'
ALTER TABLE [dbo].[CarsInSameClasses]
ADD CONSTRAINT [PK_CarsInSameClasses]
    PRIMARY KEY CLUSTERED ([CarsSameId] ASC);
GO

-- Creating primary key on [CarPsId] in table 'CarsProes'
ALTER TABLE [dbo].[CarsProes]
ADD CONSTRAINT [PK_CarsProes]
    PRIMARY KEY CLUSTERED ([CarPsId] ASC);
GO

-- Creating primary key on [CarsQnAId] in table 'CarsQnAs'
ALTER TABLE [dbo].[CarsQnAs]
ADD CONSTRAINT [PK_CarsQnAs]
    PRIMARY KEY CLUSTERED ([CarsQnAId] ASC);
GO

-- Creating primary key on [CarsReviewId] in table 'CarsReviews'
ALTER TABLE [dbo].[CarsReviews]
ADD CONSTRAINT [PK_CarsReviews]
    PRIMARY KEY CLUSTERED ([CarsReviewId] ASC);
GO

-- Creating primary key on [CarsReviewPointId] in table 'CarsReviewPoints'
ALTER TABLE [dbo].[CarsReviewPoints]
ADD CONSTRAINT [PK_CarsReviewPoints]
    PRIMARY KEY CLUSTERED ([CarsReviewPointId] ASC);
GO

-- Creating primary key on [CarsToViewId] in table 'CarsToViews'
ALTER TABLE [dbo].[CarsToViews]
ADD CONSTRAINT [PK_CarsToViews]
    PRIMARY KEY CLUSTERED ([CarsToViewId] ASC);
GO

-- Creating primary key on [CarUserCommentsId] in table 'CarUserComments'
ALTER TABLE [dbo].[CarUserComments]
ADD CONSTRAINT [PK_CarUserComments]
    PRIMARY KEY CLUSTERED ([CarUserCommentsId] ASC);
GO

-- Creating primary key on [CarWheelsId] in table 'CarWheels'
ALTER TABLE [dbo].[CarWheels]
ADD CONSTRAINT [PK_CarWheels]
    PRIMARY KEY CLUSTERED ([CarWheelsId] ASC);
GO

-- Creating primary key on [CategoryId] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([CategoryId] ASC);
GO

-- Creating primary key on [CompanyId] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [PK_Companies]
    PRIMARY KEY CLUSTERED ([CompanyId] ASC);
GO

-- Creating primary key on [MessagID] in table 'ContactUsMessages'
ALTER TABLE [dbo].[ContactUsMessages]
ADD CONSTRAINT [PK_ContactUsMessages]
    PRIMARY KEY CLUSTERED ([MessagID] ASC);
GO

-- Creating primary key on [ContentId] in table 'ContentPresentations'
ALTER TABLE [dbo].[ContentPresentations]
ADD CONSTRAINT [PK_ContentPresentations]
    PRIMARY KEY CLUSTERED ([ContentId] ASC);
GO

-- Creating primary key on [ContenstId] in table 'Contents'
ALTER TABLE [dbo].[Contents]
ADD CONSTRAINT [PK_Contents]
    PRIMARY KEY CLUSTERED ([ContenstId] ASC);
GO

-- Creating primary key on [ContentsCategoryId] in table 'ContentsCategories'
ALTER TABLE [dbo].[ContentsCategories]
ADD CONSTRAINT [PK_ContentsCategories]
    PRIMARY KEY CLUSTERED ([ContentsCategoryId] ASC);
GO

-- Creating primary key on [ContentUserCommentsId] in table 'ContentUserComments'
ALTER TABLE [dbo].[ContentUserComments]
ADD CONSTRAINT [PK_ContentUserComments]
    PRIMARY KEY CLUSTERED ([ContentUserCommentsId] ASC);
GO

-- Creating primary key on [ContentCommentsId] in table 'ContetComments'
ALTER TABLE [dbo].[ContetComments]
ADD CONSTRAINT [PK_ContetComments]
    PRIMARY KEY CLUSTERED ([ContentCommentsId] ASC);
GO

-- Creating primary key on [CountryId] in table 'Countries'
ALTER TABLE [dbo].[Countries]
ADD CONSTRAINT [PK_Countries]
    PRIMARY KEY CLUSTERED ([CountryId] ASC);
GO

-- Creating primary key on [DaysOfWeekId] in table 'DaysOfWeeks'
ALTER TABLE [dbo].[DaysOfWeeks]
ADD CONSTRAINT [PK_DaysOfWeeks]
    PRIMARY KEY CLUSTERED ([DaysOfWeekId] ASC);
GO

-- Creating primary key on [DetailedBrakeSystemId] in table 'DetailedBrakeSystems'
ALTER TABLE [dbo].[DetailedBrakeSystems]
ADD CONSTRAINT [PK_DetailedBrakeSystems]
    PRIMARY KEY CLUSTERED ([DetailedBrakeSystemId] ASC);
GO

-- Creating primary key on [DiscountId] in table 'Discounts'
ALTER TABLE [dbo].[Discounts]
ADD CONSTRAINT [PK_Discounts]
    PRIMARY KEY CLUSTERED ([DiscountId] ASC);
GO

-- Creating primary key on [FuelConsumptionId] in table 'FuelConsumptions'
ALTER TABLE [dbo].[FuelConsumptions]
ADD CONSTRAINT [PK_FuelConsumptions]
    PRIMARY KEY CLUSTERED ([FuelConsumptionId] ASC);
GO

-- Creating primary key on [GlassAndMirrorsId] in table 'GlassAndMirrors'
ALTER TABLE [dbo].[GlassAndMirrors]
ADD CONSTRAINT [PK_GlassAndMirrors]
    PRIMARY KEY CLUSTERED ([GlassAndMirrorsId] ASC);
GO

-- Creating primary key on [HomePageMenuId] in table 'HomePageMenus'
ALTER TABLE [dbo].[HomePageMenus]
ADD CONSTRAINT [PK_HomePageMenus]
    PRIMARY KEY CLUSTERED ([HomePageMenuId] ASC);
GO

-- Creating primary key on [ManufactureId] in table 'Manufactures'
ALTER TABLE [dbo].[Manufactures]
ADD CONSTRAINT [PK_Manufactures]
    PRIMARY KEY CLUSTERED ([ManufactureId] ASC);
GO

-- Creating primary key on [MarketingMailId] in table 'MarketingMails'
ALTER TABLE [dbo].[MarketingMails]
ADD CONSTRAINT [PK_MarketingMails]
    PRIMARY KEY CLUSTERED ([MarketingMailId] ASC);
GO

-- Creating primary key on [Email] in table 'NewLatterEmails'
ALTER TABLE [dbo].[NewLatterEmails]
ADD CONSTRAINT [PK_NewLatterEmails]
    PRIMARY KEY CLUSTERED ([Email] ASC);
GO

-- Creating primary key on [PersonId] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([PersonId] ASC);
GO

-- Creating primary key on [PersonCarDetailId] in table 'PersonCarDetails'
ALTER TABLE [dbo].[PersonCarDetails]
ADD CONSTRAINT [PK_PersonCarDetails]
    PRIMARY KEY CLUSTERED ([PersonCarDetailId] ASC);
GO

-- Creating primary key on [PersonCarsId] in table 'PersonCars'
ALTER TABLE [dbo].[PersonCars]
ADD CONSTRAINT [PK_PersonCars]
    PRIMARY KEY CLUSTERED ([PersonCarsId] ASC);
GO

-- Creating primary key on [PersonProductId] in table 'PersonProducts'
ALTER TABLE [dbo].[PersonProducts]
ADD CONSTRAINT [PK_PersonProducts]
    PRIMARY KEY CLUSTERED ([PersonProductId] ASC);
GO

-- Creating primary key on [PersonProductEntityId] in table 'PersonProductEntities'
ALTER TABLE [dbo].[PersonProductEntities]
ADD CONSTRAINT [PK_PersonProductEntities]
    PRIMARY KEY CLUSTERED ([PersonProductEntityId] ASC);
GO

-- Creating primary key on [PersonServicesId] in table 'PersonServices'
ALTER TABLE [dbo].[PersonServices]
ADD CONSTRAINT [PK_PersonServices]
    PRIMARY KEY CLUSTERED ([PersonServicesId] ASC);
GO

-- Creating primary key on [PersonServicesPackId] in table 'PersonServicesPacks'
ALTER TABLE [dbo].[PersonServicesPacks]
ADD CONSTRAINT [PK_PersonServicesPacks]
    PRIMARY KEY CLUSTERED ([PersonServicesPackId] ASC);
GO

-- Creating primary key on [PersonServicesUseRequestId] in table 'PersonServicesUseRequests'
ALTER TABLE [dbo].[PersonServicesUseRequests]
ADD CONSTRAINT [PK_PersonServicesUseRequests]
    PRIMARY KEY CLUSTERED ([PersonServicesUseRequestId] ASC);
GO

-- Creating primary key on [ProductId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ProductId] ASC);
GO

-- Creating primary key on [ProductCarsId] in table 'ProductCars'
ALTER TABLE [dbo].[ProductCars]
ADD CONSTRAINT [PK_ProductCars]
    PRIMARY KEY CLUSTERED ([ProductCarsId] ASC);
GO

-- Creating primary key on [ProductCommentId] in table 'ProductComments'
ALTER TABLE [dbo].[ProductComments]
ADD CONSTRAINT [PK_ProductComments]
    PRIMARY KEY CLUSTERED ([ProductCommentId] ASC);
GO

-- Creating primary key on [ProductDiscountId] in table 'ProductDiscounts'
ALTER TABLE [dbo].[ProductDiscounts]
ADD CONSTRAINT [PK_ProductDiscounts]
    PRIMARY KEY CLUSTERED ([ProductDiscountId] ASC);
GO

-- Creating primary key on [ProductInServiceId] in table 'ProductInServices'
ALTER TABLE [dbo].[ProductInServices]
ADD CONSTRAINT [PK_ProductInServices]
    PRIMARY KEY CLUSTERED ([ProductInServiceId] ASC);
GO

-- Creating primary key on [ProductPriceId] in table 'ProductPrices'
ALTER TABLE [dbo].[ProductPrices]
ADD CONSTRAINT [PK_ProductPrices]
    PRIMARY KEY CLUSTERED ([ProductPriceId] ASC);
GO

-- Creating primary key on [ProductQnAId] in table 'ProductQnAs'
ALTER TABLE [dbo].[ProductQnAs]
ADD CONSTRAINT [PK_ProductQnAs]
    PRIMARY KEY CLUSTERED ([ProductQnAId] ASC);
GO

-- Creating primary key on [ProductReviewId] in table 'ProductReviews'
ALTER TABLE [dbo].[ProductReviews]
ADD CONSTRAINT [PK_ProductReviews]
    PRIMARY KEY CLUSTERED ([ProductReviewId] ASC);
GO

-- Creating primary key on [ProductServicePackUseId] in table 'ProductServicePackUses'
ALTER TABLE [dbo].[ProductServicePackUses]
ADD CONSTRAINT [PK_ProductServicePackUses]
    PRIMARY KEY CLUSTERED ([ProductServicePackUseId] ASC);
GO

-- Creating primary key on [ProductServiceUseId] in table 'ProductServiceUses'
ALTER TABLE [dbo].[ProductServiceUses]
ADD CONSTRAINT [PK_ProductServiceUses]
    PRIMARY KEY CLUSTERED ([ProductServiceUseId] ASC);
GO

-- Creating primary key on [DeliverTypeID] in table 'ProductsOrServicesDeliveryTypes'
ALTER TABLE [dbo].[ProductsOrServicesDeliveryTypes]
ADD CONSTRAINT [PK_ProductsOrServicesDeliveryTypes]
    PRIMARY KEY CLUSTERED ([DeliverTypeID] ASC);
GO

-- Creating primary key on [ProductStoreId] in table 'ProductStores'
ALTER TABLE [dbo].[ProductStores]
ADD CONSTRAINT [PK_ProductStores]
    PRIMARY KEY CLUSTERED ([ProductStoreId] ASC);
GO

-- Creating primary key on [ProdcutToViewId] in table 'ProductToViews'
ALTER TABLE [dbo].[ProductToViews]
ADD CONSTRAINT [PK_ProductToViews]
    PRIMARY KEY CLUSTERED ([ProdcutToViewId] ASC);
GO

-- Creating primary key on [ProductUserCommentsId] in table 'ProductUserComments'
ALTER TABLE [dbo].[ProductUserComments]
ADD CONSTRAINT [PK_ProductUserComments]
    PRIMARY KEY CLUSTERED ([ProductUserCommentsId] ASC);
GO

-- Creating primary key on [ContentUserCommentsId] in table 'RootCarUserComments'
ALTER TABLE [dbo].[RootCarUserComments]
ADD CONSTRAINT [PK_RootCarUserComments]
    PRIMARY KEY CLUSTERED ([ContentUserCommentsId] ASC);
GO

-- Creating primary key on [SecuritySystemsId] in table 'SecuritySystems'
ALTER TABLE [dbo].[SecuritySystems]
ADD CONSTRAINT [PK_SecuritySystems]
    PRIMARY KEY CLUSTERED ([SecuritySystemsId] ASC);
GO

-- Creating primary key on [ServicesCategoryId] in table 'ServicesCategories'
ALTER TABLE [dbo].[ServicesCategories]
ADD CONSTRAINT [PK_ServicesCategories]
    PRIMARY KEY CLUSTERED ([ServicesCategoryId] ASC);
GO

-- Creating primary key on [ServicesPackToViewId] in table 'ServicesPackToViews'
ALTER TABLE [dbo].[ServicesPackToViews]
ADD CONSTRAINT [PK_ServicesPackToViews]
    PRIMARY KEY CLUSTERED ([ServicesPackToViewId] ASC);
GO

-- Creating primary key on [ServiceToViewId] in table 'ServiceToViews'
ALTER TABLE [dbo].[ServiceToViews]
ADD CONSTRAINT [PK_ServiceToViews]
    PRIMARY KEY CLUSTERED ([ServiceToViewId] ASC);
GO

-- Creating primary key on [SlideShowId] in table 'SlideShows'
ALTER TABLE [dbo].[SlideShows]
ADD CONSTRAINT [PK_SlideShows]
    PRIMARY KEY CLUSTERED ([SlideShowId] ASC);
GO

-- Creating primary key on [SteeringSystemId] in table 'SteeringSystems'
ALTER TABLE [dbo].[SteeringSystems]
ADD CONSTRAINT [PK_SteeringSystems]
    PRIMARY KEY CLUSTERED ([SteeringSystemId] ASC);
GO

-- Creating primary key on [TimeOfDayId] in table 'TimeOfDays'
ALTER TABLE [dbo].[TimeOfDays]
ADD CONSTRAINT [PK_TimeOfDays]
    PRIMARY KEY CLUSTERED ([TimeOfDayId] ASC);
GO

-- Creating primary key on [TodaysSpecialId] in table 'TodaysSpecials'
ALTER TABLE [dbo].[TodaysSpecials]
ADD CONSTRAINT [PK_TodaysSpecials]
    PRIMARY KEY CLUSTERED ([TodaysSpecialId] ASC);
GO

-- Creating primary key on [TroubleshootingId] in table 'Troubleshootings'
ALTER TABLE [dbo].[Troubleshootings]
ADD CONSTRAINT [PK_Troubleshootings]
    PRIMARY KEY CLUSTERED ([TroubleshootingId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [UserRoleId] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([UserRoleId] ASC);
GO

-- Creating primary key on [Cars_CarsId], [Troubleshootings_TroubleshootingId] in table 'TroubleShootingCars'
ALTER TABLE [dbo].[TroubleShootingCars]
ADD CONSTRAINT [PK_TroubleShootingCars]
    PRIMARY KEY CLUSTERED ([Cars_CarsId], [Troubleshootings_TroubleshootingId] ASC);
GO

-- Creating primary key on [Products_ProductId], [Troubleshootings_TroubleshootingId] in table 'TroubleshootingProducts'
ALTER TABLE [dbo].[TroubleshootingProducts]
ADD CONSTRAINT [PK_TroubleshootingProducts]
    PRIMARY KEY CLUSTERED ([Products_ProductId], [Troubleshootings_TroubleshootingId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CarId] in table 'AirConditioningSystems'
ALTER TABLE [dbo].[AirConditioningSystems]
ADD CONSTRAINT [FK_AirConditioningSystem_Cars]
    FOREIGN KEY ([CarId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AirConditioningSystem_Cars'
CREATE INDEX [IX_FK_AirConditioningSystem_Cars]
ON [dbo].[AirConditioningSystems]
    ([CarId]);
GO

-- Creating foreign key on [CarsId] in table 'AirConditioningSystemDetails'
ALTER TABLE [dbo].[AirConditioningSystemDetails]
ADD CONSTRAINT [FK_AirConditioningSystemDetail_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AirConditioningSystemDetail_Cars'
CREATE INDEX [IX_FK_AirConditioningSystemDetail_Cars]
ON [dbo].[AirConditioningSystemDetails]
    ([CarsId]);
GO

-- Creating foreign key on [ServicesCategoryId] in table 'AutoServices'
ALTER TABLE [dbo].[AutoServices]
ADD CONSTRAINT [FK_AutoService_ServicesCategory]
    FOREIGN KEY ([ServicesCategoryId])
    REFERENCES [dbo].[ServicesCategories]
        ([ServicesCategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutoService_ServicesCategory'
CREATE INDEX [IX_FK_AutoService_ServicesCategory]
ON [dbo].[AutoServices]
    ([ServicesCategoryId]);
GO

-- Creating foreign key on [AutoServiceId] in table 'AutoServiceCars'
ALTER TABLE [dbo].[AutoServiceCars]
ADD CONSTRAINT [FK_AutoServiceCars_AutoService]
    FOREIGN KEY ([AutoServiceId])
    REFERENCES [dbo].[AutoServices]
        ([AutoServiceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutoServiceCars_AutoService'
CREATE INDEX [IX_FK_AutoServiceCars_AutoService]
ON [dbo].[AutoServiceCars]
    ([AutoServiceId]);
GO

-- Creating foreign key on [AutoServiceId] in table 'AutoServices1'
ALTER TABLE [dbo].[AutoServices1]
ADD CONSTRAINT [FK_AutoServices_AutoService]
    FOREIGN KEY ([AutoServiceId])
    REFERENCES [dbo].[AutoServices]
        ([AutoServiceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutoServices_AutoService'
CREATE INDEX [IX_FK_AutoServices_AutoService]
ON [dbo].[AutoServices1]
    ([AutoServiceId]);
GO

-- Creating foreign key on [AutoServicesId] in table 'AutoServicesUserComments'
ALTER TABLE [dbo].[AutoServicesUserComments]
ADD CONSTRAINT [FK_AutoServicesUserComments_AutoService]
    FOREIGN KEY ([AutoServicesId])
    REFERENCES [dbo].[AutoServices]
        ([AutoServiceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutoServicesUserComments_AutoService'
CREATE INDEX [IX_FK_AutoServicesUserComments_AutoService]
ON [dbo].[AutoServicesUserComments]
    ([AutoServicesId]);
GO

-- Creating foreign key on [ServicesId] in table 'PersonServices'
ALTER TABLE [dbo].[PersonServices]
ADD CONSTRAINT [FK_PersonServices_AutoService]
    FOREIGN KEY ([ServicesId])
    REFERENCES [dbo].[AutoServices]
        ([AutoServiceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonServices_AutoService'
CREATE INDEX [IX_FK_PersonServices_AutoService]
ON [dbo].[PersonServices]
    ([ServicesId]);
GO

-- Creating foreign key on [AutoServiceId] in table 'PersonServicesUseRequests'
ALTER TABLE [dbo].[PersonServicesUseRequests]
ADD CONSTRAINT [FK_PersonServicesUseRequest_AutoService]
    FOREIGN KEY ([AutoServiceId])
    REFERENCES [dbo].[AutoServices]
        ([AutoServiceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonServicesUseRequest_AutoService'
CREATE INDEX [IX_FK_PersonServicesUseRequest_AutoService]
ON [dbo].[PersonServicesUseRequests]
    ([AutoServiceId]);
GO

-- Creating foreign key on [AutoServiceId] in table 'ProductDiscounts'
ALTER TABLE [dbo].[ProductDiscounts]
ADD CONSTRAINT [FK_ProductDiscount_AutoService]
    FOREIGN KEY ([AutoServiceId])
    REFERENCES [dbo].[AutoServices]
        ([AutoServiceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductDiscount_AutoService'
CREATE INDEX [IX_FK_ProductDiscount_AutoService]
ON [dbo].[ProductDiscounts]
    ([AutoServiceId]);
GO

-- Creating foreign key on [ServiceId] in table 'ProductInServices'
ALTER TABLE [dbo].[ProductInServices]
ADD CONSTRAINT [FK_ProductInService_AutoService]
    FOREIGN KEY ([ServiceId])
    REFERENCES [dbo].[AutoServices]
        ([AutoServiceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductInService_AutoService'
CREATE INDEX [IX_FK_ProductInService_AutoService]
ON [dbo].[ProductInServices]
    ([ServiceId]);
GO

-- Creating foreign key on [ServiceId] in table 'ServiceToViews'
ALTER TABLE [dbo].[ServiceToViews]
ADD CONSTRAINT [FK_ServiceToView_AutoService]
    FOREIGN KEY ([ServiceId])
    REFERENCES [dbo].[AutoServices]
        ([AutoServiceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceToView_AutoService'
CREATE INDEX [IX_FK_ServiceToView_AutoService]
ON [dbo].[ServiceToViews]
    ([ServiceId]);
GO

-- Creating foreign key on [CarsId] in table 'AutoServiceCars'
ALTER TABLE [dbo].[AutoServiceCars]
ADD CONSTRAINT [FK_AutoServiceCars_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutoServiceCars_Cars'
CREATE INDEX [IX_FK_AutoServiceCars_Cars]
ON [dbo].[AutoServiceCars]
    ([CarsId]);
GO

-- Creating foreign key on [AutoServicePackID] in table 'AutoServicePackUserComments'
ALTER TABLE [dbo].[AutoServicePackUserComments]
ADD CONSTRAINT [FK_AutoServicePackUserComments_AutoServicePack]
    FOREIGN KEY ([AutoServicePackID])
    REFERENCES [dbo].[AutoServicePacks]
        ([AutoServicePackId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutoServicePackUserComments_AutoServicePack'
CREATE INDEX [IX_FK_AutoServicePackUserComments_AutoServicePack]
ON [dbo].[AutoServicePackUserComments]
    ([AutoServicePackID]);
GO

-- Creating foreign key on [AutoServicePackId] in table 'AutoServices1'
ALTER TABLE [dbo].[AutoServices1]
ADD CONSTRAINT [FK_AutoServices_AutoServicePack]
    FOREIGN KEY ([AutoServicePackId])
    REFERENCES [dbo].[AutoServicePacks]
        ([AutoServicePackId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutoServices_AutoServicePack'
CREATE INDEX [IX_FK_AutoServices_AutoServicePack]
ON [dbo].[AutoServices1]
    ([AutoServicePackId]);
GO

-- Creating foreign key on [ServicesPackId] in table 'PersonServicesPacks'
ALTER TABLE [dbo].[PersonServicesPacks]
ADD CONSTRAINT [FK_PersonServicesPack_AutoServicePack]
    FOREIGN KEY ([ServicesPackId])
    REFERENCES [dbo].[AutoServicePacks]
        ([AutoServicePackId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonServicesPack_AutoServicePack'
CREATE INDEX [IX_FK_PersonServicesPack_AutoServicePack]
ON [dbo].[PersonServicesPacks]
    ([ServicesPackId]);
GO

-- Creating foreign key on [AutoServicePackId] in table 'ProductDiscounts'
ALTER TABLE [dbo].[ProductDiscounts]
ADD CONSTRAINT [FK_ProductDiscount_AutoServicePack]
    FOREIGN KEY ([AutoServicePackId])
    REFERENCES [dbo].[AutoServicePacks]
        ([AutoServicePackId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductDiscount_AutoServicePack'
CREATE INDEX [IX_FK_ProductDiscount_AutoServicePack]
ON [dbo].[ProductDiscounts]
    ([AutoServicePackId]);
GO

-- Creating foreign key on [ServicesPackId] in table 'ServicesPackToViews'
ALTER TABLE [dbo].[ServicesPackToViews]
ADD CONSTRAINT [FK_ServicesPackToView_AutoServicePack]
    FOREIGN KEY ([ServicesPackId])
    REFERENCES [dbo].[AutoServicePacks]
        ([AutoServicePackId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServicesPackToView_AutoServicePack'
CREATE INDEX [IX_FK_ServicesPackToView_AutoServicePack]
ON [dbo].[ServicesPackToViews]
    ([ServicesPackId]);
GO

-- Creating foreign key on [rootAutoServicePackUserCommentsId] in table 'AutoServicePackUserComments'
ALTER TABLE [dbo].[AutoServicePackUserComments]
ADD CONSTRAINT [FK_AutoServicePackUserComments_AutoServicePackUserComments]
    FOREIGN KEY ([rootAutoServicePackUserCommentsId])
    REFERENCES [dbo].[AutoServicePackUserComments]
        ([AutoServicePackUserCommentsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutoServicePackUserComments_AutoServicePackUserComments'
CREATE INDEX [IX_FK_AutoServicePackUserComments_AutoServicePackUserComments]
ON [dbo].[AutoServicePackUserComments]
    ([rootAutoServicePackUserCommentsId]);
GO

-- Creating foreign key on [UserId] in table 'AutoServicePackUserComments'
ALTER TABLE [dbo].[AutoServicePackUserComments]
ADD CONSTRAINT [FK_AutoServicePackUserComments_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutoServicePackUserComments_User'
CREATE INDEX [IX_FK_AutoServicePackUserComments_User]
ON [dbo].[AutoServicePackUserComments]
    ([UserId]);
GO

-- Creating foreign key on [RootAutoServicesUserCommentsId] in table 'AutoServicesUserComments'
ALTER TABLE [dbo].[AutoServicesUserComments]
ADD CONSTRAINT [FK_AutoServicesUserComments_AutoServicesUserComments]
    FOREIGN KEY ([RootAutoServicesUserCommentsId])
    REFERENCES [dbo].[AutoServicesUserComments]
        ([AutoServicesUserCommentsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutoServicesUserComments_AutoServicesUserComments'
CREATE INDEX [IX_FK_AutoServicesUserComments_AutoServicesUserComments]
ON [dbo].[AutoServicesUserComments]
    ([RootAutoServicesUserCommentsId]);
GO

-- Creating foreign key on [UserId] in table 'AutoServicesUserComments'
ALTER TABLE [dbo].[AutoServicesUserComments]
ADD CONSTRAINT [FK_AutoServicesUserComments_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutoServicesUserComments_User'
CREATE INDEX [IX_FK_AutoServicesUserComments_User]
ON [dbo].[AutoServicesUserComments]
    ([UserId]);
GO

-- Creating foreign key on [BasketId] in table 'BasketItems'
ALTER TABLE [dbo].[BasketItems]
ADD CONSTRAINT [FK_BasketItems_Baskets]
    FOREIGN KEY ([BasketId])
    REFERENCES [dbo].[Baskets]
        ([BasketId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BasketItems_Baskets'
CREATE INDEX [IX_FK_BasketItems_Baskets]
ON [dbo].[BasketItems]
    ([BasketId]);
GO

-- Creating foreign key on [DiscountId] in table 'BasketItems'
ALTER TABLE [dbo].[BasketItems]
ADD CONSTRAINT [FK_BasketItems_Discount]
    FOREIGN KEY ([DiscountId])
    REFERENCES [dbo].[Discounts]
        ([DiscountId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BasketItems_Discount'
CREATE INDEX [IX_FK_BasketItems_Discount]
ON [dbo].[BasketItems]
    ([DiscountId]);
GO

-- Creating foreign key on [DelivaryTypeId] in table 'Baskets'
ALTER TABLE [dbo].[Baskets]
ADD CONSTRAINT [FK_Baskets_Baskets]
    FOREIGN KEY ([DelivaryTypeId])
    REFERENCES [dbo].[ProductsOrServicesDeliveryTypes]
        ([DeliverTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Baskets_Baskets'
CREATE INDEX [IX_FK_Baskets_Baskets]
ON [dbo].[Baskets]
    ([DelivaryTypeId]);
GO

-- Creating foreign key on [TimeOfDayId] in table 'Baskets'
ALTER TABLE [dbo].[Baskets]
ADD CONSTRAINT [FK_Baskets_DaysOfWeek]
    FOREIGN KEY ([TimeOfDayId])
    REFERENCES [dbo].[TimeOfDays]
        ([TimeOfDayId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Baskets_DaysOfWeek'
CREATE INDEX [IX_FK_Baskets_DaysOfWeek]
ON [dbo].[Baskets]
    ([TimeOfDayId]);
GO

-- Creating foreign key on [DiscountId] in table 'Baskets'
ALTER TABLE [dbo].[Baskets]
ADD CONSTRAINT [FK_Baskets_Discount]
    FOREIGN KEY ([DiscountId])
    REFERENCES [dbo].[Discounts]
        ([DiscountId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Baskets_Discount'
CREATE INDEX [IX_FK_Baskets_Discount]
ON [dbo].[Baskets]
    ([DiscountId]);
GO

-- Creating foreign key on [UserId] in table 'Baskets'
ALTER TABLE [dbo].[Baskets]
ADD CONSTRAINT [FK_Baskets_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Baskets_User'
CREATE INDEX [IX_FK_Baskets_User]
ON [dbo].[Baskets]
    ([UserId]);
GO

-- Creating foreign key on [CarId] in table 'BrakeSystems'
ALTER TABLE [dbo].[BrakeSystems]
ADD CONSTRAINT [FK_BrakeSystem_Cars]
    FOREIGN KEY ([CarId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BrakeSystem_Cars'
CREATE INDEX [IX_FK_BrakeSystem_Cars]
ON [dbo].[BrakeSystems]
    ([CarId]);
GO

-- Creating foreign key on [CarsId] in table 'CarAirbags'
ALTER TABLE [dbo].[CarAirbags]
ADD CONSTRAINT [FK_CarAirbags_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarAirbags_Cars'
CREATE INDEX [IX_FK_CarAirbags_Cars]
ON [dbo].[CarAirbags]
    ([CarsId]);
GO

-- Creating foreign key on [CarsId] in table 'CarAudioSystems'
ALTER TABLE [dbo].[CarAudioSystems]
ADD CONSTRAINT [FK_CarAudioSystem_Cars_CarsId]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarAudioSystem_Cars_CarsId'
CREATE INDEX [IX_FK_CarAudioSystem_Cars_CarsId]
ON [dbo].[CarAudioSystems]
    ([CarsId]);
GO

-- Creating foreign key on [CarBrandId] in table 'CarModels'
ALTER TABLE [dbo].[CarModels]
ADD CONSTRAINT [FK_CarModel_CarBrand]
    FOREIGN KEY ([CarBrandId])
    REFERENCES [dbo].[CarBrands]
        ([CarBrandId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarModel_CarBrand'
CREATE INDEX [IX_FK_CarModel_CarBrand]
ON [dbo].[CarModels]
    ([CarBrandId]);
GO

-- Creating foreign key on [CarBrandId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_CarBrand]
    FOREIGN KEY ([CarBrandId])
    REFERENCES [dbo].[CarBrands]
        ([CarBrandId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_CarBrand'
CREATE INDEX [IX_FK_Product_CarBrand]
ON [dbo].[Products]
    ([CarBrandId]);
GO

-- Creating foreign key on [CarsId] in table 'CarComments'
ALTER TABLE [dbo].[CarComments]
ADD CONSTRAINT [FK_CarComments_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarComments_Cars'
CREATE INDEX [IX_FK_CarComments_Cars]
ON [dbo].[CarComments]
    ([CarsId]);
GO

-- Creating foreign key on [UserId] in table 'CarComments'
ALTER TABLE [dbo].[CarComments]
ADD CONSTRAINT [FK_CarComments_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarComments_User'
CREATE INDEX [IX_FK_CarComments_User]
ON [dbo].[CarComments]
    ([UserId]);
GO

-- Creating foreign key on [CarsId] in table 'CarDetails'
ALTER TABLE [dbo].[CarDetails]
ADD CONSTRAINT [FK_CarDetails_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarDetails_Cars'
CREATE INDEX [IX_FK_CarDetails_Cars]
ON [dbo].[CarDetails]
    ([CarsId]);
GO

-- Creating foreign key on [CarsId] in table 'CarEngines'
ALTER TABLE [dbo].[CarEngines]
ADD CONSTRAINT [FK_CarEngine_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarEngine_Cars'
CREATE INDEX [IX_FK_CarEngine_Cars]
ON [dbo].[CarEngines]
    ([CarsId]);
GO

-- Creating foreign key on [CarsId] in table 'CarGearBoxes'
ALTER TABLE [dbo].[CarGearBoxes]
ADD CONSTRAINT [FK_CarGearBox_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarGearBox_Cars'
CREATE INDEX [IX_FK_CarGearBox_Cars]
ON [dbo].[CarGearBoxes]
    ([CarsId]);
GO

-- Creating foreign key on [CarsId] in table 'CarLightingSystems'
ALTER TABLE [dbo].[CarLightingSystems]
ADD CONSTRAINT [FK_CarLightingSystem_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarLightingSystem_Cars'
CREATE INDEX [IX_FK_CarLightingSystem_Cars]
ON [dbo].[CarLightingSystems]
    ([CarsId]);
GO

-- Creating foreign key on [CarModelId] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_Cars_CarModel]
    FOREIGN KEY ([CarModelId])
    REFERENCES [dbo].[CarModels]
        ([CarModelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cars_CarModel'
CREATE INDEX [IX_FK_Cars_CarModel]
ON [dbo].[Cars]
    ([CarModelId]);
GO

-- Creating foreign key on [CarId] in table 'CarPhysicalDetails'
ALTER TABLE [dbo].[CarPhysicalDetails]
ADD CONSTRAINT [FK_CarPhysicalDetails_Cars]
    FOREIGN KEY ([CarId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarPhysicalDetails_Cars'
CREATE INDEX [IX_FK_CarPhysicalDetails_Cars]
ON [dbo].[CarPhysicalDetails]
    ([CarId]);
GO

-- Creating foreign key on [CarsId] in table 'CarPrices'
ALTER TABLE [dbo].[CarPrices]
ADD CONSTRAINT [FK_CarPrice_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarPrice_Cars'
CREATE INDEX [IX_FK_CarPrice_Cars]
ON [dbo].[CarPrices]
    ([CarsId]);
GO

-- Creating foreign key on [CountryId] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_Cars_Country]
    FOREIGN KEY ([CountryId])
    REFERENCES [dbo].[Countries]
        ([CountryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cars_Country'
CREATE INDEX [IX_FK_Cars_Country]
ON [dbo].[Cars]
    ([CountryId]);
GO

-- Creating foreign key on [CarsId] in table 'CarSeatOptions'
ALTER TABLE [dbo].[CarSeatOptions]
ADD CONSTRAINT [FK_CarSeatOptions_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarSeatOptions_Cars'
CREATE INDEX [IX_FK_CarSeatOptions_Cars]
ON [dbo].[CarSeatOptions]
    ([CarsId]);
GO

-- Creating foreign key on [CarsId] in table 'CarSensorsSystems'
ALTER TABLE [dbo].[CarSensorsSystems]
ADD CONSTRAINT [FK_CarSensorsSystem_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarSensorsSystem_Cars'
CREATE INDEX [IX_FK_CarSensorsSystem_Cars]
ON [dbo].[CarSensorsSystems]
    ([CarsId]);
GO

-- Creating foreign key on [CarsId] in table 'CarsInSameClasses'
ALTER TABLE [dbo].[CarsInSameClasses]
ADD CONSTRAINT [FK_CarsInSameClass_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarsInSameClass_Cars'
CREATE INDEX [IX_FK_CarsInSameClass_Cars]
ON [dbo].[CarsInSameClasses]
    ([CarsId]);
GO

-- Creating foreign key on [CarsSameClassId] in table 'CarsInSameClasses'
ALTER TABLE [dbo].[CarsInSameClasses]
ADD CONSTRAINT [FK_CarsInSameClass_Cars1]
    FOREIGN KEY ([CarsSameClassId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarsInSameClass_Cars1'
CREATE INDEX [IX_FK_CarsInSameClass_Cars1]
ON [dbo].[CarsInSameClasses]
    ([CarsSameClassId]);
GO

-- Creating foreign key on [CarsId] in table 'CarsProes'
ALTER TABLE [dbo].[CarsProes]
ADD CONSTRAINT [FK_CarsPro_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarsPro_Cars'
CREATE INDEX [IX_FK_CarsPro_Cars]
ON [dbo].[CarsProes]
    ([CarsId]);
GO

-- Creating foreign key on [CarsId] in table 'CarsQnAs'
ALTER TABLE [dbo].[CarsQnAs]
ADD CONSTRAINT [FK_CarsQnA_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarsQnA_Cars'
CREATE INDEX [IX_FK_CarsQnA_Cars]
ON [dbo].[CarsQnAs]
    ([CarsId]);
GO

-- Creating foreign key on [CarsId] in table 'CarsReviews'
ALTER TABLE [dbo].[CarsReviews]
ADD CONSTRAINT [FK_CarsReview_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarsReview_Cars'
CREATE INDEX [IX_FK_CarsReview_Cars]
ON [dbo].[CarsReviews]
    ([CarsId]);
GO

-- Creating foreign key on [CarsId] in table 'CarsReviewPoints'
ALTER TABLE [dbo].[CarsReviewPoints]
ADD CONSTRAINT [FK_CarsReviewPoint_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarsReviewPoint_Cars'
CREATE INDEX [IX_FK_CarsReviewPoint_Cars]
ON [dbo].[CarsReviewPoints]
    ([CarsId]);
GO

-- Creating foreign key on [CarsId] in table 'CarsToViews'
ALTER TABLE [dbo].[CarsToViews]
ADD CONSTRAINT [FK_CarsToView_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarsToView_Cars'
CREATE INDEX [IX_FK_CarsToView_Cars]
ON [dbo].[CarsToViews]
    ([CarsId]);
GO

-- Creating foreign key on [CarId] in table 'CarUserComments'
ALTER TABLE [dbo].[CarUserComments]
ADD CONSTRAINT [FK_CarUserComments_Cars]
    FOREIGN KEY ([CarId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarUserComments_Cars'
CREATE INDEX [IX_FK_CarUserComments_Cars]
ON [dbo].[CarUserComments]
    ([CarId]);
GO

-- Creating foreign key on [CarsId] in table 'CarWheels'
ALTER TABLE [dbo].[CarWheels]
ADD CONSTRAINT [FK_CarWheels_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarWheels_Cars'
CREATE INDEX [IX_FK_CarWheels_Cars]
ON [dbo].[CarWheels]
    ([CarsId]);
GO

-- Creating foreign key on [CarId] in table 'DetailedBrakeSystems'
ALTER TABLE [dbo].[DetailedBrakeSystems]
ADD CONSTRAINT [FK_DetailedBrakeSystem_Cars]
    FOREIGN KEY ([CarId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetailedBrakeSystem_Cars'
CREATE INDEX [IX_FK_DetailedBrakeSystem_Cars]
ON [dbo].[DetailedBrakeSystems]
    ([CarId]);
GO

-- Creating foreign key on [CarId] in table 'FuelConsumptions'
ALTER TABLE [dbo].[FuelConsumptions]
ADD CONSTRAINT [FK_FuelConsumption_Cars]
    FOREIGN KEY ([CarId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FuelConsumption_Cars'
CREATE INDEX [IX_FK_FuelConsumption_Cars]
ON [dbo].[FuelConsumptions]
    ([CarId]);
GO

-- Creating foreign key on [CarsId] in table 'GlassAndMirrors'
ALTER TABLE [dbo].[GlassAndMirrors]
ADD CONSTRAINT [FK_GlassAndMirrors_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GlassAndMirrors_Cars'
CREATE INDEX [IX_FK_GlassAndMirrors_Cars]
ON [dbo].[GlassAndMirrors]
    ([CarsId]);
GO

-- Creating foreign key on [CarId] in table 'PersonCars'
ALTER TABLE [dbo].[PersonCars]
ADD CONSTRAINT [FK_PersonCars_Cars]
    FOREIGN KEY ([CarId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonCars_Cars'
CREATE INDEX [IX_FK_PersonCars_Cars]
ON [dbo].[PersonCars]
    ([CarId]);
GO

-- Creating foreign key on [CarId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_Cars]
    FOREIGN KEY ([CarId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Cars'
CREATE INDEX [IX_FK_Product_Cars]
ON [dbo].[Products]
    ([CarId]);
GO

-- Creating foreign key on [CarsId] in table 'ProductCars'
ALTER TABLE [dbo].[ProductCars]
ADD CONSTRAINT [FK_ProductCars_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCars_Cars'
CREATE INDEX [IX_FK_ProductCars_Cars]
ON [dbo].[ProductCars]
    ([CarsId]);
GO

-- Creating foreign key on [CarId] in table 'SecuritySystems'
ALTER TABLE [dbo].[SecuritySystems]
ADD CONSTRAINT [FK_SecuritySystems_Cars]
    FOREIGN KEY ([CarId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SecuritySystems_Cars'
CREATE INDEX [IX_FK_SecuritySystems_Cars]
ON [dbo].[SecuritySystems]
    ([CarId]);
GO

-- Creating foreign key on [CarId] in table 'SteeringSystems'
ALTER TABLE [dbo].[SteeringSystems]
ADD CONSTRAINT [FK_SteeringSystem_Cars]
    FOREIGN KEY ([CarId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SteeringSystem_Cars'
CREATE INDEX [IX_FK_SteeringSystem_Cars]
ON [dbo].[SteeringSystems]
    ([CarId]);
GO

-- Creating foreign key on [QuestionId] in table 'CarsQnAs'
ALTER TABLE [dbo].[CarsQnAs]
ADD CONSTRAINT [FK_CarsQnA_CarsQnA]
    FOREIGN KEY ([QuestionId])
    REFERENCES [dbo].[CarsQnAs]
        ([CarsQnAId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarsQnA_CarsQnA'
CREATE INDEX [IX_FK_CarsQnA_CarsQnA]
ON [dbo].[CarsQnAs]
    ([QuestionId]);
GO

-- Creating foreign key on [LastPointId] in table 'CarsReviewPoints'
ALTER TABLE [dbo].[CarsReviewPoints]
ADD CONSTRAINT [FK_CarsReviewPoint_CarsReviewPoint]
    FOREIGN KEY ([LastPointId])
    REFERENCES [dbo].[CarsReviewPoints]
        ([CarsReviewPointId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarsReviewPoint_CarsReviewPoint'
CREATE INDEX [IX_FK_CarsReviewPoint_CarsReviewPoint]
ON [dbo].[CarsReviewPoints]
    ([LastPointId]);
GO

-- Creating foreign key on [RootCarUserCommentsId] in table 'CarUserComments'
ALTER TABLE [dbo].[CarUserComments]
ADD CONSTRAINT [FK_CarUserComments_CarUserComments]
    FOREIGN KEY ([RootCarUserCommentsId])
    REFERENCES [dbo].[CarUserComments]
        ([CarUserCommentsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarUserComments_CarUserComments'
CREATE INDEX [IX_FK_CarUserComments_CarUserComments]
ON [dbo].[CarUserComments]
    ([RootCarUserCommentsId]);
GO

-- Creating foreign key on [UserId] in table 'CarUserComments'
ALTER TABLE [dbo].[CarUserComments]
ADD CONSTRAINT [FK_CarUserComments_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarUserComments_User'
CREATE INDEX [IX_FK_CarUserComments_User]
ON [dbo].[CarUserComments]
    ([UserId]);
GO

-- Creating foreign key on [ParentCategoryId] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [FK_Category_Category]
    FOREIGN KEY ([ParentCategoryId])
    REFERENCES [dbo].[Categories]
        ([CategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Category_Category'
CREATE INDEX [IX_FK_Category_Category]
ON [dbo].[Categories]
    ([ParentCategoryId]);
GO

-- Creating foreign key on [CategoryId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_Category]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Categories]
        ([CategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Category'
CREATE INDEX [IX_FK_Product_Category]
ON [dbo].[Products]
    ([CategoryId]);
GO

-- Creating foreign key on [CompanyId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_Company]
    FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Companies]
        ([CompanyId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Company'
CREATE INDEX [IX_FK_Product_Company]
ON [dbo].[Products]
    ([CompanyId]);
GO

-- Creating foreign key on [ContentId] in table 'ContentPresentations'
ALTER TABLE [dbo].[ContentPresentations]
ADD CONSTRAINT [FK_ContentPresentation_Contents]
    FOREIGN KEY ([ContentId])
    REFERENCES [dbo].[Contents]
        ([ContenstId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ContentsCategoryId] in table 'Contents'
ALTER TABLE [dbo].[Contents]
ADD CONSTRAINT [FK_Contents_ContentsCategory]
    FOREIGN KEY ([ContentsCategoryId])
    REFERENCES [dbo].[ContentsCategories]
        ([ContentsCategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Contents_ContentsCategory'
CREATE INDEX [IX_FK_Contents_ContentsCategory]
ON [dbo].[Contents]
    ([ContentsCategoryId]);
GO

-- Creating foreign key on [ContenstId] in table 'ContentUserComments'
ALTER TABLE [dbo].[ContentUserComments]
ADD CONSTRAINT [FK_ContentUserComments_Contents]
    FOREIGN KEY ([ContenstId])
    REFERENCES [dbo].[Contents]
        ([ContenstId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContentUserComments_Contents'
CREATE INDEX [IX_FK_ContentUserComments_Contents]
ON [dbo].[ContentUserComments]
    ([ContenstId]);
GO

-- Creating foreign key on [ContentsId] in table 'ContetComments'
ALTER TABLE [dbo].[ContetComments]
ADD CONSTRAINT [FK_ContetComments_Contents]
    FOREIGN KEY ([ContentsId])
    REFERENCES [dbo].[Contents]
        ([ContenstId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContetComments_Contents'
CREATE INDEX [IX_FK_ContetComments_Contents]
ON [dbo].[ContetComments]
    ([ContentsId]);
GO

-- Creating foreign key on [ContentId] in table 'RootCarUserComments'
ALTER TABLE [dbo].[RootCarUserComments]
ADD CONSTRAINT [FK_RootCarUserComments_Contents]
    FOREIGN KEY ([ContentId])
    REFERENCES [dbo].[Contents]
        ([ContenstId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RootCarUserComments_Contents'
CREATE INDEX [IX_FK_RootCarUserComments_Contents]
ON [dbo].[RootCarUserComments]
    ([ContentId]);
GO

-- Creating foreign key on [ParentId] in table 'ContentsCategories'
ALTER TABLE [dbo].[ContentsCategories]
ADD CONSTRAINT [FK_ContentsCategory_ContentsCategory]
    FOREIGN KEY ([ParentId])
    REFERENCES [dbo].[ContentsCategories]
        ([ContentsCategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContentsCategory_ContentsCategory'
CREATE INDEX [IX_FK_ContentsCategory_ContentsCategory]
ON [dbo].[ContentsCategories]
    ([ParentId]);
GO

-- Creating foreign key on [RootContentUserCommentsId] in table 'ContentUserComments'
ALTER TABLE [dbo].[ContentUserComments]
ADD CONSTRAINT [FK_ContentUserComments_ContentUserComments2]
    FOREIGN KEY ([RootContentUserCommentsId])
    REFERENCES [dbo].[ContentUserComments]
        ([ContentUserCommentsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContentUserComments_ContentUserComments2'
CREATE INDEX [IX_FK_ContentUserComments_ContentUserComments2]
ON [dbo].[ContentUserComments]
    ([RootContentUserCommentsId]);
GO

-- Creating foreign key on [UserId] in table 'ContentUserComments'
ALTER TABLE [dbo].[ContentUserComments]
ADD CONSTRAINT [FK_ContentUserComments_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContentUserComments_User'
CREATE INDEX [IX_FK_ContentUserComments_User]
ON [dbo].[ContentUserComments]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'ContetComments'
ALTER TABLE [dbo].[ContetComments]
ADD CONSTRAINT [FK_ContetComments_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContetComments_User'
CREATE INDEX [IX_FK_ContetComments_User]
ON [dbo].[ContetComments]
    ([UserId]);
GO

-- Creating foreign key on [CountryId] in table 'Manufactures'
ALTER TABLE [dbo].[Manufactures]
ADD CONSTRAINT [FK_Manufacture_Country]
    FOREIGN KEY ([CountryId])
    REFERENCES [dbo].[Countries]
        ([CountryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Manufacture_Country'
CREATE INDEX [IX_FK_Manufacture_Country]
ON [dbo].[Manufactures]
    ([CountryId]);
GO

-- Creating foreign key on [CountryId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_Country]
    FOREIGN KEY ([CountryId])
    REFERENCES [dbo].[Countries]
        ([CountryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Country'
CREATE INDEX [IX_FK_Product_Country]
ON [dbo].[Products]
    ([CountryId]);
GO

-- Creating foreign key on [DaysOfWeekId] in table 'TimeOfDays'
ALTER TABLE [dbo].[TimeOfDays]
ADD CONSTRAINT [FK_TimeOfDay_DaysOfWeek]
    FOREIGN KEY ([DaysOfWeekId])
    REFERENCES [dbo].[DaysOfWeeks]
        ([DaysOfWeekId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TimeOfDay_DaysOfWeek'
CREATE INDEX [IX_FK_TimeOfDay_DaysOfWeek]
ON [dbo].[TimeOfDays]
    ([DaysOfWeekId]);
GO

-- Creating foreign key on [DiscountId] in table 'ProductDiscounts'
ALTER TABLE [dbo].[ProductDiscounts]
ADD CONSTRAINT [FK_ProductDiscount_Discount]
    FOREIGN KEY ([DiscountId])
    REFERENCES [dbo].[Discounts]
        ([DiscountId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductDiscount_Discount'
CREATE INDEX [IX_FK_ProductDiscount_Discount]
ON [dbo].[ProductDiscounts]
    ([DiscountId]);
GO

-- Creating foreign key on [RootHomePageMenuId] in table 'HomePageMenus'
ALTER TABLE [dbo].[HomePageMenus]
ADD CONSTRAINT [FK_HomePageMenu_HomePageMenu]
    FOREIGN KEY ([RootHomePageMenuId])
    REFERENCES [dbo].[HomePageMenus]
        ([HomePageMenuId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HomePageMenu_HomePageMenu'
CREATE INDEX [IX_FK_HomePageMenu_HomePageMenu]
ON [dbo].[HomePageMenus]
    ([RootHomePageMenuId]);
GO

-- Creating foreign key on [ManufactureId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_Manufacture]
    FOREIGN KEY ([ManufactureId])
    REFERENCES [dbo].[Manufactures]
        ([ManufactureId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Manufacture'
CREATE INDEX [IX_FK_Product_Manufacture]
ON [dbo].[Products]
    ([ManufactureId]);
GO

-- Creating foreign key on [UserId] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [FK_Person_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Person_User'
CREATE INDEX [IX_FK_Person_User]
ON [dbo].[People]
    ([UserId]);
GO

-- Creating foreign key on [PersonCarId] in table 'PersonCarDetails'
ALTER TABLE [dbo].[PersonCarDetails]
ADD CONSTRAINT [FK_PersonCarDetail_PersonCars]
    FOREIGN KEY ([PersonCarId])
    REFERENCES [dbo].[PersonCars]
        ([PersonCarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonCarDetail_PersonCars'
CREATE INDEX [IX_FK_PersonCarDetail_PersonCars]
ON [dbo].[PersonCarDetails]
    ([PersonCarId]);
GO

-- Creating foreign key on [UserId] in table 'PersonCars'
ALTER TABLE [dbo].[PersonCars]
ADD CONSTRAINT [FK_PersonCars_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonCars_User'
CREATE INDEX [IX_FK_PersonCars_User]
ON [dbo].[PersonCars]
    ([UserId]);
GO

-- Creating foreign key on [ProductId] in table 'PersonProducts'
ALTER TABLE [dbo].[PersonProducts]
ADD CONSTRAINT [FK_PersonProduct_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonProduct_Product'
CREATE INDEX [IX_FK_PersonProduct_Product]
ON [dbo].[PersonProducts]
    ([ProductId]);
GO

-- Creating foreign key on [UserId] in table 'PersonProducts'
ALTER TABLE [dbo].[PersonProducts]
ADD CONSTRAINT [FK_PersonProduct_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonProduct_User'
CREATE INDEX [IX_FK_PersonProduct_User]
ON [dbo].[PersonProducts]
    ([UserId]);
GO

-- Creating foreign key on [PersonProductId] in table 'PersonProductEntities'
ALTER TABLE [dbo].[PersonProductEntities]
ADD CONSTRAINT [FK_PersonProductEntity_PersonProduct]
    FOREIGN KEY ([PersonProductId])
    REFERENCES [dbo].[PersonProducts]
        ([PersonProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonProductEntity_PersonProduct'
CREATE INDEX [IX_FK_PersonProductEntity_PersonProduct]
ON [dbo].[PersonProductEntities]
    ([PersonProductId]);
GO

-- Creating foreign key on [UserId] in table 'PersonServices'
ALTER TABLE [dbo].[PersonServices]
ADD CONSTRAINT [FK_PersonServices_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonServices_User'
CREATE INDEX [IX_FK_PersonServices_User]
ON [dbo].[PersonServices]
    ([UserId]);
GO

-- Creating foreign key on [PersonServicesId] in table 'ProductServiceUses'
ALTER TABLE [dbo].[ProductServiceUses]
ADD CONSTRAINT [FK_ProductServiceUse_PersonServices]
    FOREIGN KEY ([PersonServicesId])
    REFERENCES [dbo].[PersonServices]
        ([PersonServicesId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductServiceUse_PersonServices'
CREATE INDEX [IX_FK_ProductServiceUse_PersonServices]
ON [dbo].[ProductServiceUses]
    ([PersonServicesId]);
GO

-- Creating foreign key on [UserId] in table 'PersonServicesPacks'
ALTER TABLE [dbo].[PersonServicesPacks]
ADD CONSTRAINT [FK_PersonServicesPack_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonServicesPack_User'
CREATE INDEX [IX_FK_PersonServicesPack_User]
ON [dbo].[PersonServicesPacks]
    ([UserId]);
GO

-- Creating foreign key on [PersonServicesPackId] in table 'ProductServicePackUses'
ALTER TABLE [dbo].[ProductServicePackUses]
ADD CONSTRAINT [FK_ProductServicePackUse_PersonServicesPack]
    FOREIGN KEY ([PersonServicesPackId])
    REFERENCES [dbo].[PersonServicesPacks]
        ([PersonServicesPackId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductServicePackUse_PersonServicesPack'
CREATE INDEX [IX_FK_ProductServicePackUse_PersonServicesPack]
ON [dbo].[ProductServicePackUses]
    ([PersonServicesPackId]);
GO

-- Creating foreign key on [UserId] in table 'PersonServicesUseRequests'
ALTER TABLE [dbo].[PersonServicesUseRequests]
ADD CONSTRAINT [FK_PersonServicesUseRequest_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonServicesUseRequest_User'
CREATE INDEX [IX_FK_PersonServicesUseRequest_User]
ON [dbo].[PersonServicesUseRequests]
    ([UserId]);
GO

-- Creating foreign key on [ProductReviewId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_ProductReview]
    FOREIGN KEY ([ProductReviewId])
    REFERENCES [dbo].[ProductReviews]
        ([ProductReviewId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_ProductReview'
CREATE INDEX [IX_FK_Product_ProductReview]
ON [dbo].[Products]
    ([ProductReviewId]);
GO

-- Creating foreign key on [ProductId] in table 'ProductCars'
ALTER TABLE [dbo].[ProductCars]
ADD CONSTRAINT [FK_ProductCars_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCars_Product'
CREATE INDEX [IX_FK_ProductCars_Product]
ON [dbo].[ProductCars]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'ProductComments'
ALTER TABLE [dbo].[ProductComments]
ADD CONSTRAINT [FK_ProductComments_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductComments_Product'
CREATE INDEX [IX_FK_ProductComments_Product]
ON [dbo].[ProductComments]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'ProductDiscounts'
ALTER TABLE [dbo].[ProductDiscounts]
ADD CONSTRAINT [FK_ProductDiscount_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductDiscount_Product'
CREATE INDEX [IX_FK_ProductDiscount_Product]
ON [dbo].[ProductDiscounts]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'ProductInServices'
ALTER TABLE [dbo].[ProductInServices]
ADD CONSTRAINT [FK_ProductInService_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductInService_Product'
CREATE INDEX [IX_FK_ProductInService_Product]
ON [dbo].[ProductInServices]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'ProductPrices'
ALTER TABLE [dbo].[ProductPrices]
ADD CONSTRAINT [FK_ProductPrice_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductPrice_Product'
CREATE INDEX [IX_FK_ProductPrice_Product]
ON [dbo].[ProductPrices]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'ProductQnAs'
ALTER TABLE [dbo].[ProductQnAs]
ADD CONSTRAINT [FK_ProductQnA_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductQnA_Product'
CREATE INDEX [IX_FK_ProductQnA_Product]
ON [dbo].[ProductQnAs]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'ProductStores'
ALTER TABLE [dbo].[ProductStores]
ADD CONSTRAINT [FK_ProductStore_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductStore_Product'
CREATE INDEX [IX_FK_ProductStore_Product]
ON [dbo].[ProductStores]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'ProductToViews'
ALTER TABLE [dbo].[ProductToViews]
ADD CONSTRAINT [FK_ProductToView_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductToView_Product'
CREATE INDEX [IX_FK_ProductToView_Product]
ON [dbo].[ProductToViews]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'ProductUserComments'
ALTER TABLE [dbo].[ProductUserComments]
ADD CONSTRAINT [FK_ProductUserComments_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductUserComments_Product'
CREATE INDEX [IX_FK_ProductUserComments_Product]
ON [dbo].[ProductUserComments]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'TodaysSpecials'
ALTER TABLE [dbo].[TodaysSpecials]
ADD CONSTRAINT [FK_TodaysSpecial_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TodaysSpecial_Product'
CREATE INDEX [IX_FK_TodaysSpecial_Product]
ON [dbo].[TodaysSpecials]
    ([ProductId]);
GO

-- Creating foreign key on [UserId] in table 'ProductComments'
ALTER TABLE [dbo].[ProductComments]
ADD CONSTRAINT [FK_ProductComments_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductComments_User'
CREATE INDEX [IX_FK_ProductComments_User]
ON [dbo].[ProductComments]
    ([UserId]);
GO

-- Creating foreign key on [QuestionId] in table 'ProductQnAs'
ALTER TABLE [dbo].[ProductQnAs]
ADD CONSTRAINT [FK_ProductQnA_ProductQnA]
    FOREIGN KEY ([QuestionId])
    REFERENCES [dbo].[ProductQnAs]
        ([ProductQnAId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductQnA_ProductQnA'
CREATE INDEX [IX_FK_ProductQnA_ProductQnA]
ON [dbo].[ProductQnAs]
    ([QuestionId]);
GO

-- Creating foreign key on [RootProductUserCommentsId] in table 'ProductUserComments'
ALTER TABLE [dbo].[ProductUserComments]
ADD CONSTRAINT [FK_ProductUserComments_ProductUserComments]
    FOREIGN KEY ([RootProductUserCommentsId])
    REFERENCES [dbo].[ProductUserComments]
        ([ProductUserCommentsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductUserComments_ProductUserComments'
CREATE INDEX [IX_FK_ProductUserComments_ProductUserComments]
ON [dbo].[ProductUserComments]
    ([RootProductUserCommentsId]);
GO

-- Creating foreign key on [UserId] in table 'ProductUserComments'
ALTER TABLE [dbo].[ProductUserComments]
ADD CONSTRAINT [FK_ProductUserComments_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductUserComments_User'
CREATE INDEX [IX_FK_ProductUserComments_User]
ON [dbo].[ProductUserComments]
    ([UserId]);
GO

-- Creating foreign key on [RootContentUserCommentsId] in table 'RootCarUserComments'
ALTER TABLE [dbo].[RootCarUserComments]
ADD CONSTRAINT [FK_RootCarUserComments_RootCarUserComments]
    FOREIGN KEY ([RootContentUserCommentsId])
    REFERENCES [dbo].[RootCarUserComments]
        ([ContentUserCommentsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RootCarUserComments_RootCarUserComments'
CREATE INDEX [IX_FK_RootCarUserComments_RootCarUserComments]
ON [dbo].[RootCarUserComments]
    ([RootContentUserCommentsId]);
GO

-- Creating foreign key on [UserId] in table 'RootCarUserComments'
ALTER TABLE [dbo].[RootCarUserComments]
ADD CONSTRAINT [FK_RootCarUserComments_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RootCarUserComments_User'
CREATE INDEX [IX_FK_RootCarUserComments_User]
ON [dbo].[RootCarUserComments]
    ([UserId]);
GO

-- Creating foreign key on [ServicesParentCategoryId] in table 'ServicesCategories'
ALTER TABLE [dbo].[ServicesCategories]
ADD CONSTRAINT [FK_ServicesCategory_ServicesCategory]
    FOREIGN KEY ([ServicesParentCategoryId])
    REFERENCES [dbo].[ServicesCategories]
        ([ServicesCategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServicesCategory_ServicesCategory'
CREATE INDEX [IX_FK_ServicesCategory_ServicesCategory]
ON [dbo].[ServicesCategories]
    ([ServicesParentCategoryId]);
GO

-- Creating foreign key on [UserRoleId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_UserRole]
    FOREIGN KEY ([UserRoleId])
    REFERENCES [dbo].[UserRoles]
        ([UserRoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_UserRole'
CREATE INDEX [IX_FK_User_UserRole]
ON [dbo].[Users]
    ([UserRoleId]);
GO

-- Creating foreign key on [Cars_CarsId] in table 'TroubleShootingCars'
ALTER TABLE [dbo].[TroubleShootingCars]
ADD CONSTRAINT [FK_TroubleShootingCars_Cars]
    FOREIGN KEY ([Cars_CarsId])
    REFERENCES [dbo].[Cars]
        ([CarsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Troubleshootings_TroubleshootingId] in table 'TroubleShootingCars'
ALTER TABLE [dbo].[TroubleShootingCars]
ADD CONSTRAINT [FK_TroubleShootingCars_Troubleshooting]
    FOREIGN KEY ([Troubleshootings_TroubleshootingId])
    REFERENCES [dbo].[Troubleshootings]
        ([TroubleshootingId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TroubleShootingCars_Troubleshooting'
CREATE INDEX [IX_FK_TroubleShootingCars_Troubleshooting]
ON [dbo].[TroubleShootingCars]
    ([Troubleshootings_TroubleshootingId]);
GO

-- Creating foreign key on [Products_ProductId] in table 'TroubleshootingProducts'
ALTER TABLE [dbo].[TroubleshootingProducts]
ADD CONSTRAINT [FK_TroubleshootingProducts_Product]
    FOREIGN KEY ([Products_ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Troubleshootings_TroubleshootingId] in table 'TroubleshootingProducts'
ALTER TABLE [dbo].[TroubleshootingProducts]
ADD CONSTRAINT [FK_TroubleshootingProducts_Troubleshooting]
    FOREIGN KEY ([Troubleshootings_TroubleshootingId])
    REFERENCES [dbo].[Troubleshootings]
        ([TroubleshootingId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TroubleshootingProducts_Troubleshooting'
CREATE INDEX [IX_FK_TroubleshootingProducts_Troubleshooting]
ON [dbo].[TroubleshootingProducts]
    ([Troubleshootings_TroubleshootingId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------