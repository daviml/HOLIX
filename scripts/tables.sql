create table tuser (
	userid varchar(32) primary key,
	name varchar(32),
	email varchar(32),
	login varchar(32),
	password varchar(32)
);

create table taddress (
	addressid varchar(32) primary key,
	userid varchar(32) references tuser (userid),
	street varchar(32),
	number varchar(32),
	complement varchar(32),
	neighborhood varchar(32),
	postalcode varchar(32),
	city varchar(32),
	state varchar(32),
	country varchar(32)
);
