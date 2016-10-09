USE [CarAutomation]
GO

/****** Object:  Table [dbo].[AirConditioningSystem]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AirConditioningSystem](
	[AirConditioningSystemId] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NULL,
	[AirConditioningType] [nvarchar](50) NULL,
	[Details] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[AirConditioningSystemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[AirConditioningSystemDetail]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AirConditioningSystemDetail](
	[AirConditioningSystemDetailId] [int] IDENTITY(1,1) NOT NULL,
	[AirConditioningSystemDetailSubject] [nvarchar](50) NULL,
	[AirConditioningSystemDetail] [nvarchar](max) NULL,
	[CarsId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AirConditioningSystemDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[AutoService]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AutoService](
	[AutoServiceId] [int] IDENTITY(1,1) NOT NULL,
	[AutoServiceName] [nvarchar](50) NULL,
	[HasCarId] [bit] NULL,
	[CarId] [int] NULL,
	[HasProduct] [bit] NULL,
	[Price] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[AutoServicePack]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AutoServicePack](
	[AutoServicePackId] [int] IDENTITY(1,1) NOT NULL,
	[AutoServicePackName] [nvarchar](50) NULL,
	[PackPrice] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoServicePackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[AutoServices]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AutoServices](
	[AutoServicesId] [int] IDENTITY(1,1) NOT NULL,
	[AutoServiceId] [int] NULL,
	[AutoServicePackId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoServicesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Basket]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Basket](
	[BasketId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[date] [datetime] NULL,
	[BasketCode] [nvarchar](50) NULL,
	[TotalPrice] [int] NULL,
	[OnlineOrInPlace] [bit] NULL,
	[BackCodeFromBank] [nvarchar](100) NULL,
	[DateToDeliver] [date] NULL,
	[HourToDeliver] [time](7) NULL,
	[IsFinished] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[BasketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[BrakeSystem]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BrakeSystem](
	[BrakeSystemId] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NULL,
	[FrontBrakeSystem] [nvarchar](50) NULL,
	[RearBrakeSystem] [nvarchar](50) NULL,
	[OtherSystem] [nvarchar](max) NULL,
	[HandBrakeSystem] [nvarchar](50) NULL,
	[Details] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[BrakeSystemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CarAirbags]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarAirbags](
	[CarAirbagsId] [int] IDENTITY(1,1) NOT NULL,
	[DriverAirBag] [bit] NULL,
	[FrontAirBag] [bit] NULL,
	[AirBag] [bit] NULL,
	[AirBagEntity] [int] NULL,
	[Details] [nvarchar](max) NULL,
	[CarsId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CarAirbagsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CarAudioSystem]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarAudioSystem](
	[CarAudioSystemId] [int] IDENTITY(1,1) NOT NULL,
	[AudioSystemType] [nvarchar](50) NULL,
	[AudioSystemBrand] [nvarchar](50) NULL,
	[HasMonitor] [bit] NULL,
	[RearSeatsMonitor] [bit] NULL,
	[RearGearCamera] [bit] NULL,
	[FrontCamera] [bit] NULL,
	[RearStereo] [nvarchar](50) NULL,
	[FrontStereo] [nvarchar](50) NULL,
	[Subwoofer] [nvarchar](50) NULL,
	[Amplifire] [nvarchar](50) NULL,
	[HasGps] [bit] NULL,
	[Details] [nvarchar](max) NULL,
	[CarsId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CarAudioSystemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CarBrand]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarBrand](
	[CarBrandId] [int] IDENTITY(1,1) NOT NULL,
	[CarBrandName] [nvarchar](150) NULL,
	[CarBrandHistory] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[CarBrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CarEngine]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarEngine](
	[CarEngineId] [int] IDENTITY(1,1) NOT NULL,
	[EngineType] [nvarchar](50) NULL,
	[EngineCylinderNumber] [int] NULL,
	[EnginePowerHpRpm] [int] NULL,
	[EngineTorque] [int] NULL,
	[EnginePowerHpTon] [int] NULL,
	[EnginePowerHpLitr] [int] NULL,
	[EngineMaxSpeed] [int] NULL,
	[EngineZeroToH] [float] NULL,
	[EngineDescription] [nvarchar](max) NULL,
	[CarsId] [int] NULL,
	[EngineSize] [int] NULL,
	[EngineFuel] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CarEngineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CarGearBox]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarGearBox](
	[CarGearBoxId] [int] IDENTITY(1,1) NOT NULL,
	[GearBoxCode] [nvarchar](50) NULL,
	[GearBoxType] [nvarchar](50) NULL,
	[GearBoxCanBeManual] [bit] NULL,
	[GearBoxShiftNumber] [int] NULL,
	[GearBoxAxel] [nvarchar](50) NULL,
	[HasTransferCase] [bit] NULL,
	[GearBoxDiffrentionalLock] [bit] NULL,
	[GearBoxWdType] [nvarchar](50) NULL,
	[GearBoxDescription] [nvarchar](max) NULL,
	[CarsId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CarGearBoxId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CarLightingSystem]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarLightingSystem](
	[CarLightingSystemId] [int] IDENTITY(1,1) NOT NULL,
	[FrontLights] [nvarchar](50) NULL,
	[RearLights] [nvarchar](50) NULL,
	[DayLight] [bit] NULL,
	[SideMirrorLight] [bit] NULL,
	[FonrAntiFog] [bit] NULL,
	[RearAntiFog] [bit] NULL,
	[ReadingLamp] [bit] NULL,
	[Deailts] [nvarchar](max) NULL,
	[CarsId] [int] NULL,
	[ThirdLightStop] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CarLightingSystemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CarModel]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarModel](
	[CarModelId] [int] IDENTITY(1,1) NOT NULL,
	[CarModelName] [nvarchar](150) NULL,
	[CarBrandId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CarModelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CarPhysicalDetails]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarPhysicalDetails](
	[CarPhysicalDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[CarLength] [int] NULL,
	[Carwidth] [int] NULL,
	[CarHeight] [int] NULL,
	[CarTrack] [int] NULL,
	[CarWheelBase] [int] NULL,
	[CarPureWeight] [int] NULL,
	[CarTankSize] [int] NULL,
	[Details] [nvarchar](max) NULL,
	[CarId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CarPhysicalDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CarPrice]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarPrice](
	[CarPriceId] [int] IDENTITY(1,1) NOT NULL,
	[CarsId] [int] NULL,
	[Price] [float] NULL,
	[Date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CarPriceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Cars]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cars](
	[CarsId] [int] IDENTITY(1,1) NOT NULL,
	[CarModelId] [int] NULL,
	[CarsClass] [nvarchar](50) NULL,
	[CarsUserScore] [float] NULL,
	[CarsClinicScore] [float] NULL,
	[Price] [int] NULL,
	[CarsPicsId] [int] NULL,
	[CarsVideoURL] [nvarchar](50) NULL,
	[CarsDescription] [nvarchar](max) NULL,
	[CarClassType] [nvarchar](50) NULL,
	[CarCategory] [nvarchar](50) NULL,
	[CarUsage] [nvarchar](100) NULL,
	[CarYearModel] [int] NULL,
	[CarBodyType] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CarsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CarSeatOptions]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarSeatOptions](
	[CarSeatOptionsId] [int] IDENTITY(1,1) NOT NULL,
	[LongitudinalDisplacement] [bit] NULL,
	[BezelSet] [bit] NULL,
	[SeatWarmer] [bit] NULL,
	[SeatMassage] [bit] NULL,
	[HasMemory] [bit] NULL,
	[Details] [nvarchar](max) NULL,
	[CarsId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CarSeatOptionsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CarSensorsSystem]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarSensorsSystem](
	[CarSensorsSystemId] [int] IDENTITY(1,1) NOT NULL,
	[DayLightSensor] [bit] NULL,
	[RainSensor] [bit] NULL,
	[RearGearSensor] [bit] NULL,
	[ParkSensor] [bit] NULL,
	[NavigateSensor] [bit] NULL,
	[CruiseControl] [bit] NULL,
	[RearGearCamera] [bit] NULL,
	[Details] [nvarchar](max) NULL,
	[CarsId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CarSensorsSystemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CarsInSameClass]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarsInSameClass](
	[CarsSameId] [int] IDENTITY(1,1) NOT NULL,
	[CarsId] [int] NULL,
	[CarsSameClassId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CarsSameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CarsPro]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarsPro](
	[CarPsId] [int] IDENTITY(1,1) NOT NULL,
	[CarsId] [int] NULL,
	[CarsProOrCro] [bit] NULL,
	[CarProCro] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CarPsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CarsQnA]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarsQnA](
	[CarsQnAId] [int] IDENTITY(1,1) NOT NULL,
	[CarsId] [int] NULL,
	[QuestionType] [nvarchar](150) NULL,
	[Question] [nvarchar](450) NULL,
	[QuestionId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CarsQnAId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CarsReview]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarsReview](
	[CarsReviewId] [int] IDENTITY(1,1) NOT NULL,
	[CarsId] [int] NULL,
	[Review] [nvarchar](max) NULL,
	[CarScore] [float] NULL,
	[Beauty] [float] NULL,
	[WorthBuying] [float] NULL,
	[Quality] [float] NULL,
	[Services] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[CarsReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CarsReviewPoint]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarsReviewPoint](
	[CarsReviewPointId] [int] IDENTITY(1,1) NOT NULL,
	[CarsReviewSubject] [nvarchar](50) NULL,
	[CarsReview] [nvarchar](max) NULL,
	[CarsId] [int] NULL,
	[LastPointId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CarsReviewPointId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CarWheels]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarWheels](
	[CarWheelsId] [int] IDENTITY(1,1) NOT NULL,
	[CarsId] [int] NULL,
	[TireType] [nvarchar](50) NULL,
	[RingStandardSize] [int] NULL,
	[TireSpec] [nvarchar](50) NULL,
	[RingType] [nvarchar](50) NULL,
	[RingModel] [nvarchar](50) NULL,
	[AutoInflated] [bit] NULL,
	[Details] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[CarWheelsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Category]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
	[ParentCategoryId] [int] NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Company]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Company](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[CompanyAddress] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ContactUsMessages]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ContactUsMessages](
	[MessagID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](255) NULL,
	[Subject] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[Message] [nvarchar](max) NULL,
	[Date] [datetime] NULL,
	[Seen] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MessagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ContentPresentation]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ContentPresentation](
	[ContentId] [int] NOT NULL,
	[ShowCount] [int] NULL,
	[Like] [int] NULL,
	[Dislike] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ContentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Contents]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contents](
	[ContenstId] [int] IDENTITY(1,1) NOT NULL,
	[ContentsCategoryId] [int] NULL,
	[ContentSubject] [nvarchar](150) NULL,
	[ContentDescribe] [nvarchar](max) NULL,
	[ContentText] [ntext] NULL,
	[VideoUrl] [nvarchar](255) NULL,
	[ContentType] [nchar](10) NULL,
	[tags] [nvarchar](350) NULL,
	[Date] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ContenstId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ContentsCategory]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ContentsCategory](
	[ContentsCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Describe] [nvarchar](max) NULL,
	[ParentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ContentsCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Country]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryShortName] [nvarchar](50) NULL,
	[CountryLongName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[DetailedBrakeSystem]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DetailedBrakeSystem](
	[DetailedBrakeSystemId] [int] IDENTITY(1,1) NOT NULL,
	[DetailedName] [nvarchar](50) NULL,
	[HaveDetailed] [bit] NULL,
	[CarId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DetailedBrakeSystemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Discount]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Discount](
	[DiscountId] [int] IDENTITY(1,1) NOT NULL,
	[DiscountCode] [nvarchar](50) NULL,
	[Discount] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[DiscountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[FuelConsumption]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FuelConsumption](
	[FuelConsumptionId] [int] IDENTITY(1,1) NOT NULL,
	[LphCity] [float] NULL,
	[LphRoad] [float] NULL,
	[LphMix] [float] NULL,
	[Details] [nvarchar](max) NULL,
	[ReservedOne] [nvarchar](50) NULL,
	[ReservedTwo] [nvarchar](50) NULL,
	[ReservedThree] [nvarchar](50) NULL,
	[CarId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[FuelConsumptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[GlassAndMirrors]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GlassAndMirrors](
	[GlassAndMirrorsId] [int] IDENTITY(1,1) NOT NULL,
	[FrontWindscreens] [nvarchar](50) NULL,
	[RearWindscreens] [nvarchar](50) NULL,
	[SunRoof] [bit] NULL,
	[PanaromaRoof] [bit] NULL,
	[RearGlassWarmer] [bit] NULL,
	[WindscreensWarmer] [bit] NULL,
	[FrontGlassWarmer] [bit] NULL,
	[SideMirrorSet] [nvarchar](50) NULL,
	[SideMirrorSystem] [nvarchar](50) NULL,
	[Details] [nvarchar](max) NULL,
	[CarsId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[GlassAndMirrorsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Manufacture]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Manufacture](
	[ManufactureId] [int] IDENTITY(1,1) NOT NULL,
	[ManufactureName] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NULL,
	[ManufacturePhon] [nvarchar](50) NULL,
	[CountryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ManufactureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Person]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Person](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[PersonFirtstName] [nvarchar](50) NULL,
	[PersonLastName] [nvarchar](50) NULL,
	[PersonPhone] [nvarchar](50) NULL,
	[PersonMobile] [nvarchar](50) NULL,
	[PersonEmail] [nvarchar](50) NULL,
	[PersonAddressCity] [nvarchar](50) NULL,
	[PersonAddress] [nvarchar](max) NULL,
	[UserId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PersonCarDetail]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PersonCarDetail](
	[PersonCarDetailId] [int] IDENTITY(1,1) NOT NULL,
	[PersonCarId] [int] NULL,
	[LastOilChange] [date] NULL,
	[LastFiltersChange] [date] NULL,
	[LastOilChangeMilage] [int] NULL,
	[LastFilterChangeMilage] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonCarDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PersonCars]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PersonCars](
	[PersonCarsId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CarId] [int] NULL,
	[CarMilage] [int] NULL,
	[CarCreationDate] [nvarchar](50) NULL,
	[CarColor] [nvarchar](50) NULL,
	[CarPlate] [nvarchar](50) NULL,
	[CarPlateCityCode] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonCarsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PersonProduct]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PersonProduct](
	[PersonProductId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ProductId] [int] NULL,
	[ProductCurrentEntity] [int] NULL,
	[DateAdded] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PersonProductEntity]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PersonProductEntity](
	[PersonProductEntityId] [int] IDENTITY(1,1) NOT NULL,
	[PersonProductId] [int] NULL,
	[DateUsed] [date] NULL,
	[EntityUsed] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonProductEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PersonServices]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PersonServices](
	[PersonServicesId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ServicesId] [int] NULL,
	[ServicesCurrentEntity] [int] NULL,
	[DateAdded] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonServicesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PersonServicesPack]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PersonServicesPack](
	[PersonServicesPackId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ServicesPackId] [int] NULL,
	[ServicesPackCurrentEntity] [int] NULL,
	[DateAdded] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonServicesPackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Product]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[CarId] [int] NULL,
	[CategoryId] [int] NULL,
	[ProductHeight] [float] NULL,
	[ProductWidth] [float] NULL,
	[CompanyId] [int] NULL,
	[ProductWeight] [float] NULL,
	[ProductLength] [float] NULL,
	[CountryId] [int] NULL,
	[ManufactureId] [int] NULL,
	[ProductSecription] [nvarchar](max) NULL,
	[PartNumber] [int] NULL,
	[MetaTags] [nvarchar](max) NULL,
	[ProductRating] [float] NULL,
	[ProductReviewId] [int] NULL,
	[ProductQnAId] [int] NULL,
	[DiscountId] [int] NULL,
	[WithInstall] [bit] NULL,
 CONSTRAINT [PK__Product__B40CC6CD68C0AFB1] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ProductCars]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductCars](
	[RID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[CarsId] [int] NULL,
 CONSTRAINT [PK_ProductCars] PRIMARY KEY CLUSTERED 
(
	[RID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ProductDiscount]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductDiscount](
	[ProductDiscountId] [int] IDENTITY(1,1) NOT NULL,
	[ProductDiscount] [int] NULL,
	[ProductId] [int] NULL,
	[DiscountId] [int] NULL,
	[AutoServiceId] [int] NULL,
	[AutoServicePackId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductDiscountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ProductInService]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductInService](
	[ProductInServiceId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [int] NULL,
	[ProductId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductInServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ProductPrice]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductPrice](
	[ProductPriceId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[ProductPrice] [int] NULL,
	[Date] [date] NULL,
	[InstallPrice] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductPriceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ProductQnA]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductQnA](
	[ProductQnAId] [int] IDENTITY(1,1) NOT NULL,
	[ProductQuestion] [nvarchar](150) NULL,
	[HasAnswer] [bit] NULL,
	[HasFather] [bit] NULL,
	[FatherId] [int] NULL,
	[Answer] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductQnAId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ProductReview]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductReview](
	[ProductReviewId] [int] IDENTITY(1,1) NOT NULL,
	[ProductReview] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ProductServicePackUse]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductServicePackUse](
	[ProductServicePackUseId] [int] IDENTITY(1,1) NOT NULL,
	[PersonServicesPackId] [int] NULL,
	[DateUsed] [date] NULL,
	[EntityUsed] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductServicePackUseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ProductServiceUse]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductServiceUse](
	[ProductServiceUseId] [int] IDENTITY(1,1) NOT NULL,
	[PersonServicesId] [int] NULL,
	[DateUsed] [date] NULL,
	[EntityUsed] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductServiceUseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ProductStore]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductStore](
	[ProductStoreId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[ProductEntity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductStoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ProductToView]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductToView](
	[ProdcutToViewId] [int] IDENTITY(1,1) NOT NULL,
	[Viewd] [int] NULL,
	[ProductId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProdcutToViewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[SecuritySystems]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SecuritySystems](
	[SecuritySystemsId] [int] IDENTITY(1,1) NOT NULL,
	[RemoteControl] [bit] NULL,
	[BurglarAlarm] [bit] NULL,
	[Alarm] [bit] NULL,
	[Emo] [bit] NULL,
	[KeylessDoor] [bit] NULL,
	[KeylessStart] [bit] NULL,
	[Details] [nvarchar](max) NULL,
	[CarId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SecuritySystemsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ServicesPackToView]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ServicesPackToView](
	[ServicesPackToViewId] [int] IDENTITY(1,1) NOT NULL,
	[Viewd] [int] NULL,
	[ServicesPackId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ServicesPackToViewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ServiceToView]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ServiceToView](
	[ServiceToViewId] [int] IDENTITY(1,1) NOT NULL,
	[Views] [int] NULL,
	[ServiceId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceToViewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[SlideShows]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SlideShows](
	[SlideShowId] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](255) NULL,
	[Describe] [nvarchar](max) NULL,
	[Image] [nvarchar](255) NULL,
	[Url] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[SlideShowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[SteeringSystem]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SteeringSystem](
	[SteeringSystemId] [int] IDENTITY(1,1) NOT NULL,
	[SteeringSystemType] [nvarchar](50) NULL,
	[SteeringType] [nvarchar](50) NULL,
	[SteeringHeightAdjustble] [bit] NULL,
	[SteeringControlKey] [bit] NULL,
	[Details] [nvarchar](max) NULL,
	[CarId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SteeringSystemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ToBasket]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ToBasket](
	[ToBasketId] [int] IDENTITY(1,1) NOT NULL,
	[BasketId] [int] NULL,
	[ProductId] [int] NULL,
	[ProductEntity] [int] NULL,
	[AutoServiceId] [int] NULL,
	[AutoServiceEntity] [int] NULL,
	[AutoServicePackId] [int] NULL,
	[AutoSericePackEntity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ToBasketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[TodaysSpecial]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TodaysSpecial](
	[TodaysSpecialId] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NULL,
	[ProductId] [int] NULL,
	[Discount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TodaysSpecialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Troubleshooting]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Troubleshooting](
	[TroubleshootingId] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](150) NULL,
	[Answer] [nvarchar](max) NULL,
	[AnswerYesOrNo] [bit] NULL,
	[HasFather] [bit] NULL,
	[FatherId] [int] NULL,
	[HasProduct] [bit] NULL,
	[ProductId] [int] NULL,
	[ServicePrice] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TroubleshootingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[User]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Uname] [nvarchar](50) NULL,
	[Upass] [nvarchar](50) NULL,
	[UserRoleId] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[UserRole]    Script Date: 10/10/2016 00:15:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserRole](
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[UserRole] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[AirConditioningSystem]  WITH CHECK ADD  CONSTRAINT [FK_AirConditioningSystem_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[AirConditioningSystem] CHECK CONSTRAINT [FK_AirConditioningSystem_Cars]
GO

ALTER TABLE [dbo].[AirConditioningSystemDetail]  WITH CHECK ADD  CONSTRAINT [FK_AirConditioningSystemDetail_Cars] FOREIGN KEY([CarsId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[AirConditioningSystemDetail] CHECK CONSTRAINT [FK_AirConditioningSystemDetail_Cars]
GO

ALTER TABLE [dbo].[AutoService]  WITH CHECK ADD  CONSTRAINT [FK_AutoService_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[AutoService] CHECK CONSTRAINT [FK_AutoService_Cars]
GO

ALTER TABLE [dbo].[AutoServices]  WITH CHECK ADD  CONSTRAINT [FK_AutoServices_AutoService] FOREIGN KEY([AutoServiceId])
REFERENCES [dbo].[AutoService] ([AutoServiceId])
GO

ALTER TABLE [dbo].[AutoServices] CHECK CONSTRAINT [FK_AutoServices_AutoService]
GO

ALTER TABLE [dbo].[AutoServices]  WITH CHECK ADD  CONSTRAINT [FK_AutoServices_AutoServicePack] FOREIGN KEY([AutoServicePackId])
REFERENCES [dbo].[AutoServicePack] ([AutoServicePackId])
GO

ALTER TABLE [dbo].[AutoServices] CHECK CONSTRAINT [FK_AutoServices_AutoServicePack]
GO

ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_User]
GO

ALTER TABLE [dbo].[BrakeSystem]  WITH CHECK ADD  CONSTRAINT [FK_BrakeSystem_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[BrakeSystem] CHECK CONSTRAINT [FK_BrakeSystem_Cars]
GO

ALTER TABLE [dbo].[CarAirbags]  WITH CHECK ADD  CONSTRAINT [FK_CarAirbags_Cars] FOREIGN KEY([CarsId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[CarAirbags] CHECK CONSTRAINT [FK_CarAirbags_Cars]
GO

ALTER TABLE [dbo].[CarAudioSystem]  WITH CHECK ADD  CONSTRAINT [FK_CarAudioSystem_Cars_CarsId] FOREIGN KEY([CarsId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[CarAudioSystem] CHECK CONSTRAINT [FK_CarAudioSystem_Cars_CarsId]
GO

ALTER TABLE [dbo].[CarEngine]  WITH CHECK ADD  CONSTRAINT [FK_CarEngine_Cars] FOREIGN KEY([CarsId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[CarEngine] CHECK CONSTRAINT [FK_CarEngine_Cars]
GO

ALTER TABLE [dbo].[CarGearBox]  WITH CHECK ADD  CONSTRAINT [FK_CarGearBox_Cars] FOREIGN KEY([CarsId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[CarGearBox] CHECK CONSTRAINT [FK_CarGearBox_Cars]
GO

ALTER TABLE [dbo].[CarLightingSystem]  WITH CHECK ADD  CONSTRAINT [FK_CarLightingSystem_Cars] FOREIGN KEY([CarsId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[CarLightingSystem] CHECK CONSTRAINT [FK_CarLightingSystem_Cars]
GO

ALTER TABLE [dbo].[CarModel]  WITH CHECK ADD  CONSTRAINT [FK_CarModel_CarBrand] FOREIGN KEY([CarBrandId])
REFERENCES [dbo].[CarBrand] ([CarBrandId])
GO

ALTER TABLE [dbo].[CarModel] CHECK CONSTRAINT [FK_CarModel_CarBrand]
GO

ALTER TABLE [dbo].[CarPhysicalDetails]  WITH CHECK ADD  CONSTRAINT [FK_CarPhysicalDetails_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[CarPhysicalDetails] CHECK CONSTRAINT [FK_CarPhysicalDetails_Cars]
GO

ALTER TABLE [dbo].[CarPrice]  WITH CHECK ADD  CONSTRAINT [FK_CarPrice_Cars] FOREIGN KEY([CarsId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[CarPrice] CHECK CONSTRAINT [FK_CarPrice_Cars]
GO

ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_CarModel] FOREIGN KEY([CarModelId])
REFERENCES [dbo].[CarModel] ([CarModelId])
GO

ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_CarModel]
GO

ALTER TABLE [dbo].[CarSeatOptions]  WITH CHECK ADD  CONSTRAINT [FK_CarSeatOptions_Cars] FOREIGN KEY([CarsId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[CarSeatOptions] CHECK CONSTRAINT [FK_CarSeatOptions_Cars]
GO

ALTER TABLE [dbo].[CarSensorsSystem]  WITH CHECK ADD  CONSTRAINT [FK_CarSensorsSystem_Cars] FOREIGN KEY([CarsId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[CarSensorsSystem] CHECK CONSTRAINT [FK_CarSensorsSystem_Cars]
GO

ALTER TABLE [dbo].[CarsInSameClass]  WITH CHECK ADD  CONSTRAINT [FK_CarsInSameClass_Cars] FOREIGN KEY([CarsId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[CarsInSameClass] CHECK CONSTRAINT [FK_CarsInSameClass_Cars]
GO

ALTER TABLE [dbo].[CarsInSameClass]  WITH CHECK ADD  CONSTRAINT [FK_CarsInSameClass_Cars1] FOREIGN KEY([CarsSameClassId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[CarsInSameClass] CHECK CONSTRAINT [FK_CarsInSameClass_Cars1]
GO

ALTER TABLE [dbo].[CarsPro]  WITH CHECK ADD  CONSTRAINT [FK_CarsPro_Cars] FOREIGN KEY([CarsId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[CarsPro] CHECK CONSTRAINT [FK_CarsPro_Cars]
GO

ALTER TABLE [dbo].[CarsQnA]  WITH CHECK ADD  CONSTRAINT [FK_CarsQnA_Cars] FOREIGN KEY([CarsId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[CarsQnA] CHECK CONSTRAINT [FK_CarsQnA_Cars]
GO

ALTER TABLE [dbo].[CarsQnA]  WITH CHECK ADD  CONSTRAINT [FK_CarsQnA_CarsQnA] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[CarsQnA] ([CarsQnAId])
GO

ALTER TABLE [dbo].[CarsQnA] CHECK CONSTRAINT [FK_CarsQnA_CarsQnA]
GO

ALTER TABLE [dbo].[CarsReview]  WITH CHECK ADD  CONSTRAINT [FK_CarsReview_Cars] FOREIGN KEY([CarsId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[CarsReview] CHECK CONSTRAINT [FK_CarsReview_Cars]
GO

ALTER TABLE [dbo].[CarsReviewPoint]  WITH CHECK ADD  CONSTRAINT [FK_CarsReviewPoint_Cars] FOREIGN KEY([CarsId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[CarsReviewPoint] CHECK CONSTRAINT [FK_CarsReviewPoint_Cars]
GO

ALTER TABLE [dbo].[CarsReviewPoint]  WITH CHECK ADD  CONSTRAINT [FK_CarsReviewPoint_CarsReviewPoint] FOREIGN KEY([LastPointId])
REFERENCES [dbo].[CarsReviewPoint] ([CarsReviewPointId])
GO

ALTER TABLE [dbo].[CarsReviewPoint] CHECK CONSTRAINT [FK_CarsReviewPoint_CarsReviewPoint]
GO

ALTER TABLE [dbo].[CarWheels]  WITH CHECK ADD  CONSTRAINT [FK_CarWheels_Cars] FOREIGN KEY([CarsId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[CarWheels] CHECK CONSTRAINT [FK_CarWheels_Cars]
GO

ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Category] FOREIGN KEY([ParentCategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO

ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Category]
GO

ALTER TABLE [dbo].[ContentPresentation]  WITH CHECK ADD  CONSTRAINT [FK_ContentPresentation_Contents] FOREIGN KEY([ContentId])
REFERENCES [dbo].[Contents] ([ContenstId])
GO

ALTER TABLE [dbo].[ContentPresentation] CHECK CONSTRAINT [FK_ContentPresentation_Contents]
GO

ALTER TABLE [dbo].[Contents]  WITH CHECK ADD  CONSTRAINT [FK_Contents_ContentsCategory] FOREIGN KEY([ContentsCategoryId])
REFERENCES [dbo].[ContentsCategory] ([ContentsCategoryId])
GO

ALTER TABLE [dbo].[Contents] CHECK CONSTRAINT [FK_Contents_ContentsCategory]
GO

ALTER TABLE [dbo].[ContentsCategory]  WITH CHECK ADD  CONSTRAINT [FK_ContentsCategory_ContentsCategory] FOREIGN KEY([ParentId])
REFERENCES [dbo].[ContentsCategory] ([ContentsCategoryId])
GO

ALTER TABLE [dbo].[ContentsCategory] CHECK CONSTRAINT [FK_ContentsCategory_ContentsCategory]
GO

ALTER TABLE [dbo].[DetailedBrakeSystem]  WITH CHECK ADD  CONSTRAINT [FK_DetailedBrakeSystem_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[DetailedBrakeSystem] CHECK CONSTRAINT [FK_DetailedBrakeSystem_Cars]
GO

ALTER TABLE [dbo].[FuelConsumption]  WITH CHECK ADD  CONSTRAINT [FK_FuelConsumption_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[FuelConsumption] CHECK CONSTRAINT [FK_FuelConsumption_Cars]
GO

ALTER TABLE [dbo].[GlassAndMirrors]  WITH CHECK ADD  CONSTRAINT [FK_GlassAndMirrors_Cars] FOREIGN KEY([CarsId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[GlassAndMirrors] CHECK CONSTRAINT [FK_GlassAndMirrors_Cars]
GO

ALTER TABLE [dbo].[Manufacture]  WITH CHECK ADD  CONSTRAINT [FK_Manufacture_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO

ALTER TABLE [dbo].[Manufacture] CHECK CONSTRAINT [FK_Manufacture_Country]
GO

ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_User]
GO

ALTER TABLE [dbo].[PersonCarDetail]  WITH CHECK ADD  CONSTRAINT [FK_PersonCarDetail_PersonCars] FOREIGN KEY([PersonCarId])
REFERENCES [dbo].[PersonCars] ([PersonCarsId])
GO

ALTER TABLE [dbo].[PersonCarDetail] CHECK CONSTRAINT [FK_PersonCarDetail_PersonCars]
GO

ALTER TABLE [dbo].[PersonCars]  WITH CHECK ADD  CONSTRAINT [FK_PersonCars_Cars] FOREIGN KEY([PersonCarsId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[PersonCars] CHECK CONSTRAINT [FK_PersonCars_Cars]
GO

ALTER TABLE [dbo].[PersonCars]  WITH CHECK ADD  CONSTRAINT [FK_PersonCars_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[PersonCars] CHECK CONSTRAINT [FK_PersonCars_User]
GO

ALTER TABLE [dbo].[PersonProduct]  WITH CHECK ADD  CONSTRAINT [FK_PersonProduct_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO

ALTER TABLE [dbo].[PersonProduct] CHECK CONSTRAINT [FK_PersonProduct_Product]
GO

ALTER TABLE [dbo].[PersonProduct]  WITH CHECK ADD  CONSTRAINT [FK_PersonProduct_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[PersonProduct] CHECK CONSTRAINT [FK_PersonProduct_User]
GO

ALTER TABLE [dbo].[PersonProductEntity]  WITH CHECK ADD  CONSTRAINT [FK_PersonProductEntity_PersonProduct] FOREIGN KEY([PersonProductId])
REFERENCES [dbo].[PersonProduct] ([PersonProductId])
GO

ALTER TABLE [dbo].[PersonProductEntity] CHECK CONSTRAINT [FK_PersonProductEntity_PersonProduct]
GO

ALTER TABLE [dbo].[PersonServices]  WITH CHECK ADD  CONSTRAINT [FK_PersonServices_AutoService] FOREIGN KEY([ServicesId])
REFERENCES [dbo].[AutoService] ([AutoServiceId])
GO

ALTER TABLE [dbo].[PersonServices] CHECK CONSTRAINT [FK_PersonServices_AutoService]
GO

ALTER TABLE [dbo].[PersonServices]  WITH CHECK ADD  CONSTRAINT [FK_PersonServices_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[PersonServices] CHECK CONSTRAINT [FK_PersonServices_User]
GO

ALTER TABLE [dbo].[PersonServicesPack]  WITH CHECK ADD  CONSTRAINT [FK_PersonServicesPack_AutoServicePack] FOREIGN KEY([ServicesPackId])
REFERENCES [dbo].[AutoServicePack] ([AutoServicePackId])
GO

ALTER TABLE [dbo].[PersonServicesPack] CHECK CONSTRAINT [FK_PersonServicesPack_AutoServicePack]
GO

ALTER TABLE [dbo].[PersonServicesPack]  WITH CHECK ADD  CONSTRAINT [FK_PersonServicesPack_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[PersonServicesPack] CHECK CONSTRAINT [FK_PersonServicesPack_User]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Cars]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([CompanyId])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Company]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Country]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Manufacture] FOREIGN KEY([ManufactureId])
REFERENCES [dbo].[Manufacture] ([ManufactureId])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Manufacture]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductQnA] FOREIGN KEY([ProductQnAId])
REFERENCES [dbo].[ProductQnA] ([ProductQnAId])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductQnA]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductReview] FOREIGN KEY([ProductReviewId])
REFERENCES [dbo].[ProductReview] ([ProductReviewId])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductReview]
GO

ALTER TABLE [dbo].[ProductCars]  WITH CHECK ADD  CONSTRAINT [FK_ProductCars_Cars] FOREIGN KEY([CarsId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[ProductCars] CHECK CONSTRAINT [FK_ProductCars_Cars]
GO

ALTER TABLE [dbo].[ProductCars]  WITH CHECK ADD  CONSTRAINT [FK_ProductCars_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO

ALTER TABLE [dbo].[ProductCars] CHECK CONSTRAINT [FK_ProductCars_Product]
GO

ALTER TABLE [dbo].[ProductDiscount]  WITH CHECK ADD  CONSTRAINT [FK_ProductDiscount_AutoService] FOREIGN KEY([AutoServiceId])
REFERENCES [dbo].[AutoService] ([AutoServiceId])
GO

ALTER TABLE [dbo].[ProductDiscount] CHECK CONSTRAINT [FK_ProductDiscount_AutoService]
GO

ALTER TABLE [dbo].[ProductDiscount]  WITH CHECK ADD  CONSTRAINT [FK_ProductDiscount_AutoServicePack] FOREIGN KEY([AutoServicePackId])
REFERENCES [dbo].[AutoServicePack] ([AutoServicePackId])
GO

ALTER TABLE [dbo].[ProductDiscount] CHECK CONSTRAINT [FK_ProductDiscount_AutoServicePack]
GO

ALTER TABLE [dbo].[ProductDiscount]  WITH CHECK ADD  CONSTRAINT [FK_ProductDiscount_Discount] FOREIGN KEY([DiscountId])
REFERENCES [dbo].[Discount] ([DiscountId])
GO

ALTER TABLE [dbo].[ProductDiscount] CHECK CONSTRAINT [FK_ProductDiscount_Discount]
GO

ALTER TABLE [dbo].[ProductDiscount]  WITH CHECK ADD  CONSTRAINT [FK_ProductDiscount_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO

ALTER TABLE [dbo].[ProductDiscount] CHECK CONSTRAINT [FK_ProductDiscount_Product]
GO

ALTER TABLE [dbo].[ProductInService]  WITH CHECK ADD  CONSTRAINT [FK_ProductInService_AutoService] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[AutoService] ([AutoServiceId])
GO

ALTER TABLE [dbo].[ProductInService] CHECK CONSTRAINT [FK_ProductInService_AutoService]
GO

ALTER TABLE [dbo].[ProductInService]  WITH CHECK ADD  CONSTRAINT [FK_ProductInService_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO

ALTER TABLE [dbo].[ProductInService] CHECK CONSTRAINT [FK_ProductInService_Product]
GO

ALTER TABLE [dbo].[ProductPrice]  WITH CHECK ADD  CONSTRAINT [FK_ProductPrice_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO

ALTER TABLE [dbo].[ProductPrice] CHECK CONSTRAINT [FK_ProductPrice_Product]
GO

ALTER TABLE [dbo].[ProductQnA]  WITH CHECK ADD  CONSTRAINT [FK_ProductQnA_ProductQnA] FOREIGN KEY([FatherId])
REFERENCES [dbo].[ProductQnA] ([ProductQnAId])
GO

ALTER TABLE [dbo].[ProductQnA] CHECK CONSTRAINT [FK_ProductQnA_ProductQnA]
GO

ALTER TABLE [dbo].[ProductServicePackUse]  WITH CHECK ADD  CONSTRAINT [FK_ProductServicePackUse_PersonServicesPack] FOREIGN KEY([PersonServicesPackId])
REFERENCES [dbo].[PersonServicesPack] ([PersonServicesPackId])
GO

ALTER TABLE [dbo].[ProductServicePackUse] CHECK CONSTRAINT [FK_ProductServicePackUse_PersonServicesPack]
GO

ALTER TABLE [dbo].[ProductServiceUse]  WITH CHECK ADD  CONSTRAINT [FK_ProductServiceUse_PersonServices] FOREIGN KEY([PersonServicesId])
REFERENCES [dbo].[PersonServices] ([PersonServicesId])
GO

ALTER TABLE [dbo].[ProductServiceUse] CHECK CONSTRAINT [FK_ProductServiceUse_PersonServices]
GO

ALTER TABLE [dbo].[ProductStore]  WITH CHECK ADD  CONSTRAINT [FK_ProductStore_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO

ALTER TABLE [dbo].[ProductStore] CHECK CONSTRAINT [FK_ProductStore_Product]
GO

ALTER TABLE [dbo].[ProductToView]  WITH CHECK ADD  CONSTRAINT [FK_ProductToView_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO

ALTER TABLE [dbo].[ProductToView] CHECK CONSTRAINT [FK_ProductToView_Product]
GO

ALTER TABLE [dbo].[SecuritySystems]  WITH CHECK ADD  CONSTRAINT [FK_SecuritySystems_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[SecuritySystems] CHECK CONSTRAINT [FK_SecuritySystems_Cars]
GO

ALTER TABLE [dbo].[ServicesPackToView]  WITH CHECK ADD  CONSTRAINT [FK_ServicesPackToView_AutoServicePack] FOREIGN KEY([ServicesPackId])
REFERENCES [dbo].[AutoServicePack] ([AutoServicePackId])
GO

ALTER TABLE [dbo].[ServicesPackToView] CHECK CONSTRAINT [FK_ServicesPackToView_AutoServicePack]
GO

ALTER TABLE [dbo].[ServiceToView]  WITH CHECK ADD  CONSTRAINT [FK_ServiceToView_AutoService] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[AutoService] ([AutoServiceId])
GO

ALTER TABLE [dbo].[ServiceToView] CHECK CONSTRAINT [FK_ServiceToView_AutoService]
GO

ALTER TABLE [dbo].[SteeringSystem]  WITH CHECK ADD  CONSTRAINT [FK_SteeringSystem_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarsId])
GO

ALTER TABLE [dbo].[SteeringSystem] CHECK CONSTRAINT [FK_SteeringSystem_Cars]
GO

ALTER TABLE [dbo].[ToBasket]  WITH CHECK ADD  CONSTRAINT [FK_ToBasket_AutoService] FOREIGN KEY([AutoServiceId])
REFERENCES [dbo].[AutoService] ([AutoServiceId])
GO

ALTER TABLE [dbo].[ToBasket] CHECK CONSTRAINT [FK_ToBasket_AutoService]
GO

ALTER TABLE [dbo].[ToBasket]  WITH CHECK ADD  CONSTRAINT [FK_ToBasket_AutoServicePack] FOREIGN KEY([AutoServicePackId])
REFERENCES [dbo].[AutoServicePack] ([AutoServicePackId])
GO

ALTER TABLE [dbo].[ToBasket] CHECK CONSTRAINT [FK_ToBasket_AutoServicePack]
GO

ALTER TABLE [dbo].[ToBasket]  WITH CHECK ADD  CONSTRAINT [FK_ToBasket_Basket] FOREIGN KEY([BasketId])
REFERENCES [dbo].[Basket] ([BasketId])
GO

ALTER TABLE [dbo].[ToBasket] CHECK CONSTRAINT [FK_ToBasket_Basket]
GO

ALTER TABLE [dbo].[ToBasket]  WITH CHECK ADD  CONSTRAINT [FK_ToBasket_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO

ALTER TABLE [dbo].[ToBasket] CHECK CONSTRAINT [FK_ToBasket_Product]
GO

ALTER TABLE [dbo].[TodaysSpecial]  WITH CHECK ADD  CONSTRAINT [FK_TodaysSpecial_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO

ALTER TABLE [dbo].[TodaysSpecial] CHECK CONSTRAINT [FK_TodaysSpecial_Product]
GO

ALTER TABLE [dbo].[Troubleshooting]  WITH CHECK ADD  CONSTRAINT [FK_Troubleshooting_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO

ALTER TABLE [dbo].[Troubleshooting] CHECK CONSTRAINT [FK_Troubleshooting_Product]
GO

ALTER TABLE [dbo].[Troubleshooting]  WITH CHECK ADD  CONSTRAINT [FK_Troubleshooting_Troubleshooting] FOREIGN KEY([FatherId])
REFERENCES [dbo].[Troubleshooting] ([TroubleshootingId])
GO

ALTER TABLE [dbo].[Troubleshooting] CHECK CONSTRAINT [FK_Troubleshooting_Troubleshooting]
GO

ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserRole] FOREIGN KEY([UserRoleId])
REFERENCES [dbo].[UserRole] ([UserRoleId])
GO

ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserRole]
GO

