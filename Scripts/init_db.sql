create table vivel.FAQ
(
	FAQID char(36) not null primary key,
	Question nvarchar(max),
	Answer nvarchar(max),
	Answered bit,
	CreatedAt datetime,
	UpdatedAt datetime
);

create table vivel.Hospital
(
	HospitalID char(36) not null primary key,
	Name nvarchar(100),
	Location geography,
	CreatedAt datetime,
	UpdatedAt datetime
);

create table vivel.PresetBadge
(
	PresetBadgeId char(36) not null primary key,
	Name nvarchar(100),
	Description nvarchar(max),
	Picture nvarchar(max),
	CreatedAt datetime,
	UpdatedAt datetime
);

create table vivel.[User]
(
	UserID char(36) not null primary key,
	BloodType varchar(3),
	Verified bit,
	CreatedAt datetime,
	UpdatedAt datetime,
	Location geography,
);

create table vivel.Badge
(
	BadgeID char(36) not null primary key,
	UserID char(36) foreign key references vivel.[User](UserID),
	PresetBadgeId char(36) foreign key references vivel.PresetBadge(PresetBadgeID),
	Name nvarchar(100),
	CreatedAt datetime,
	UpdatedAt datetime,
);

create table vivel.Drive
(
	DriveID char(36) not null primary key,
	HospitalID char(36) foreign key references vivel.Hospital(HospitalID),
	Date datetime,
	BloodType varchar(3),
	Amount int,
	Status nvarchar(50),
	Urgency bit,
	CreatedAt datetime,
	UpdatedAt datetime,
);

create table vivel.Donation
(
	DonationID char(36) not null primary key,
	UserID char(36) foreign key references vivel.[User](UserID),
	DriveID char(36) foreign key references vivel.Drive(DriveID),
	ScheduledAt datetime,
	Status nvarchar(50),
	Note nvarchar(max),
	LeukocyteCount int,
	ErythrocyteCount int,
	PlateletCount int,
	CreatedAt datetime,
	UpdatedAt datetime,
);

create table vivel.Notification
(
	NotificationID char(36) not null primary key,
	UserID char(36) foreign key references vivel.[User](UserID),
	Title nvarchar(100),
	Content nvarchar(max),
	LinkID char(36),
	LinkType nvarchar(100),
	CreatedAt datetime,
	UpdatedAt datetime,
);
