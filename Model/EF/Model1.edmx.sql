
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/31/2021 23:40:33
-- Generated from EDMX file: F:\projectNhom\MainVnnews\Model\EF\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DBvnews];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Groups_Categorys]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Groups] DROP CONSTRAINT [FK_Groups_Categorys];
GO
IF OBJECT_ID(N'[dbo].[FK_Comments_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_Comments_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Replys_Comments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Replys] DROP CONSTRAINT [FK_Replys_Comments];
GO
IF OBJECT_ID(N'[dbo].[FK_Editors_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Editors] DROP CONSTRAINT [FK_Editors_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Groups_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Groups] DROP CONSTRAINT [FK_Groups_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_news_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[News] DROP CONSTRAINT [FK_news_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Reports_news]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reports] DROP CONSTRAINT [FK_Reports_news];
GO
IF OBJECT_ID(N'[dbo].[FK_Replys_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Replys] DROP CONSTRAINT [FK_Replys_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Reports_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reports] DROP CONSTRAINT [FK_Reports_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Groups_News]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Groups] DROP CONSTRAINT [FK_Groups_News];
GO
IF OBJECT_ID(N'[dbo].[FK_Users_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_Roles];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categorys]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categorys];
GO
IF OBJECT_ID(N'[dbo].[Comments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments];
GO
IF OBJECT_ID(N'[dbo].[Editors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Editors];
GO
IF OBJECT_ID(N'[dbo].[Groups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Groups];
GO
IF OBJECT_ID(N'[dbo].[News]', 'U') IS NOT NULL
    DROP TABLE [dbo].[News];
GO
IF OBJECT_ID(N'[dbo].[Replys]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Replys];
GO
IF OBJECT_ID(N'[dbo].[Reports]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reports];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categorys'
CREATE TABLE [dbo].[Categorys] (
    [category_id] int IDENTITY(1,1) NOT NULL,
    [category_name] nvarchar(max)  NULL,
    [category_view] int  NULL,
    [category_active] bit  NULL,
    [category_datecreate] datetime  NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [comment_id] int IDENTITY(1,1) NOT NULL,
    [comment_content] nvarchar(max)  NULL,
    [comment_datecreate] datetime  NULL,
    [user_id] int  NULL,
    [news_id] int  NULL
);
GO

-- Creating table 'Editors'
CREATE TABLE [dbo].[Editors] (
    [editor_id] int IDENTITY(1,1) NOT NULL,
    [editor_fullname] nvarchar(300)  NULL,
    [editor_sex] bit  NULL,
    [editor_fb] nvarchar(max)  NULL,
    [editor_phone] varchar(15)  NULL,
    [editor_time] nvarchar(100)  NULL,
    [editor_intro] nvarchar(max)  NULL,
    [editor_interests] nvarchar(max)  NULL,
    [editor_enthusiasm] nvarchar(max)  NULL,
    [user_id] int  NULL,
    [editor_zalo] varchar(15)  NULL,
    [editor_active] bit  NULL,
    [editor_status] int  NULL
);
GO

-- Creating table 'Groups'
CREATE TABLE [dbo].[Groups] (
    [group_id] int IDENTITY(1,1) NOT NULL,
    [news_id] int  NULL,
    [user_id] int  NULL,
    [group_item] int  NULL,
    [group_datecreate] datetime  NULL,
    [category_id] int  NULL
);
GO

-- Creating table 'News'
CREATE TABLE [dbo].[News] (
    [vnew_id] int IDENTITY(1,1) NOT NULL,
    [vnew_title] nvarchar(max)  NULL,
    [vnew_content] nvarchar(max)  NULL,
    [vnew_view] int  NULL,
    [vnew_active] bit  NULL,
    [vnew_option] bit  NULL,
    [vnew_datecreate] datetime  NULL,
    [vnew_dateupdate] datetime  NULL,
    [user_id] int  NULL,
    [vnews_des] nvarchar(1000)  NULL,
    [vnew_img] nvarchar(max)  NULL
);
GO

-- Creating table 'Replys'
CREATE TABLE [dbo].[Replys] (
    [reply_id] int IDENTITY(1,1) NOT NULL,
    [reply_content] nvarchar(max)  NULL,
    [reply_datecreate] datetime  NULL,
    [user_id] int  NULL,
    [comment_id] int  NULL
);
GO

-- Creating table 'Reports'
CREATE TABLE [dbo].[Reports] (
    [report_id] int IDENTITY(1,1) NOT NULL,
    [report_content] nvarchar(max)  NULL,
    [dow_id] int  NULL,
    [report_datecreate] datetime  NULL,
    [user_id] int  NULL,
    [news_id] int  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [role_id] int IDENTITY(1,1) NOT NULL,
    [role_name] nvarchar(200)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [user_id] int IDENTITY(1,1) NOT NULL,
    [user_name] nvarchar(200)  NULL,
    [user_password] nvarchar(50)  NULL,
    [user_image] nvarchar(max)  NULL,
    [user_phone] varchar(14)  NULL,
    [user_active] bit  NULL,
    [user_bin] bit  NULL,
    [user_datecreate] datetime  NULL,
    [user_dateupdate] datetime  NULL,
    [user_datelogin] datetime  NULL,
    [user_email] varchar(255)  NULL,
    [role_id] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [category_id] in table 'Categorys'
ALTER TABLE [dbo].[Categorys]
ADD CONSTRAINT [PK_Categorys]
    PRIMARY KEY CLUSTERED ([category_id] ASC);
GO

-- Creating primary key on [comment_id] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([comment_id] ASC);
GO

-- Creating primary key on [editor_id] in table 'Editors'
ALTER TABLE [dbo].[Editors]
ADD CONSTRAINT [PK_Editors]
    PRIMARY KEY CLUSTERED ([editor_id] ASC);
GO

-- Creating primary key on [group_id] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [PK_Groups]
    PRIMARY KEY CLUSTERED ([group_id] ASC);
GO

-- Creating primary key on [vnew_id] in table 'News'
ALTER TABLE [dbo].[News]
ADD CONSTRAINT [PK_News]
    PRIMARY KEY CLUSTERED ([vnew_id] ASC);
GO

-- Creating primary key on [reply_id] in table 'Replys'
ALTER TABLE [dbo].[Replys]
ADD CONSTRAINT [PK_Replys]
    PRIMARY KEY CLUSTERED ([reply_id] ASC);
GO

-- Creating primary key on [report_id] in table 'Reports'
ALTER TABLE [dbo].[Reports]
ADD CONSTRAINT [PK_Reports]
    PRIMARY KEY CLUSTERED ([report_id] ASC);
GO

-- Creating primary key on [role_id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([role_id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [user_id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([user_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [category_id] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [FK_Groups_Categorys]
    FOREIGN KEY ([category_id])
    REFERENCES [dbo].[Categorys]
        ([category_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Groups_Categorys'
CREATE INDEX [IX_FK_Groups_Categorys]
ON [dbo].[Groups]
    ([category_id]);
GO

-- Creating foreign key on [user_id] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_Comments_Users]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([user_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Comments_Users'
CREATE INDEX [IX_FK_Comments_Users]
ON [dbo].[Comments]
    ([user_id]);
GO

-- Creating foreign key on [comment_id] in table 'Replys'
ALTER TABLE [dbo].[Replys]
ADD CONSTRAINT [FK_Replys_Comments]
    FOREIGN KEY ([comment_id])
    REFERENCES [dbo].[Comments]
        ([comment_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Replys_Comments'
CREATE INDEX [IX_FK_Replys_Comments]
ON [dbo].[Replys]
    ([comment_id]);
GO

-- Creating foreign key on [user_id] in table 'Editors'
ALTER TABLE [dbo].[Editors]
ADD CONSTRAINT [FK_Editors_Users]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([user_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Editors_Users'
CREATE INDEX [IX_FK_Editors_Users]
ON [dbo].[Editors]
    ([user_id]);
GO

-- Creating foreign key on [user_id] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [FK_Groups_Users]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([user_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Groups_Users'
CREATE INDEX [IX_FK_Groups_Users]
ON [dbo].[Groups]
    ([user_id]);
GO

-- Creating foreign key on [user_id] in table 'News'
ALTER TABLE [dbo].[News]
ADD CONSTRAINT [FK_news_Users]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([user_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_news_Users'
CREATE INDEX [IX_FK_news_Users]
ON [dbo].[News]
    ([user_id]);
GO

-- Creating foreign key on [news_id] in table 'Reports'
ALTER TABLE [dbo].[Reports]
ADD CONSTRAINT [FK_Reports_news]
    FOREIGN KEY ([news_id])
    REFERENCES [dbo].[News]
        ([vnew_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Reports_news'
CREATE INDEX [IX_FK_Reports_news]
ON [dbo].[Reports]
    ([news_id]);
GO

-- Creating foreign key on [user_id] in table 'Replys'
ALTER TABLE [dbo].[Replys]
ADD CONSTRAINT [FK_Replys_Users]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([user_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Replys_Users'
CREATE INDEX [IX_FK_Replys_Users]
ON [dbo].[Replys]
    ([user_id]);
GO

-- Creating foreign key on [user_id] in table 'Reports'
ALTER TABLE [dbo].[Reports]
ADD CONSTRAINT [FK_Reports_Users]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([user_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Reports_Users'
CREATE INDEX [IX_FK_Reports_Users]
ON [dbo].[Reports]
    ([user_id]);
GO

-- Creating foreign key on [news_id] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [FK_Groups_News]
    FOREIGN KEY ([news_id])
    REFERENCES [dbo].[News]
        ([vnew_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Groups_News'
CREATE INDEX [IX_FK_Groups_News]
ON [dbo].[Groups]
    ([news_id]);
GO

-- Creating foreign key on [role_id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_Users_Roles]
    FOREIGN KEY ([role_id])
    REFERENCES [dbo].[Roles]
        ([role_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Users_Roles'
CREATE INDEX [IX_FK_Users_Roles]
ON [dbo].[Users]
    ([role_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------