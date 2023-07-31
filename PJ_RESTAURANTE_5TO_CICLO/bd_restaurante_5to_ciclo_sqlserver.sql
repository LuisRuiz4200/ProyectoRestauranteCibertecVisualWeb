drop database if exists BD_RESTAURANTE_5TO_CICLO
go

create database BD_RESTAURANTE_5TO_CICLO
go

use BD_RESTAURANTE_5TO_CICLO
go

create table tb_tipo_usuario(
	id_tipo_usuario int identity(1,1) not null primary key,
    des_tipo_usuario varchar(100) not null
)
go

create table tb_tipo_colaborador(
	id_tipo_colaborador int identity(1,1) not null primary key,
    des_tipo_colaborador varchar(100) not null
)
go

create table tb_distrito (
	id_distrito int identity(1,1) not null primary key,
    des_distrito varchar(100) not null
)
go

create table tb_mediopago(
	id_medio_pago int identity(1,1) not null primary key,
    des_medio_pago varchar(100) not null
)
go

create table tb_categoria_producto(
	id_categoria_producto int identity(1,1) not null primary key,
    des_categoria_producto varchar(100) not null
)
go

create table tb_usuario(
	id_usuario int identity(1,1) not null primary key,
    id_tipo_usuario int not null , 
    cod_usuario varchar(100) not null,
    nom_usuario varchar(100) not null,
    ape_usuario varchar(100) not null,
    tel_usuario char(12),
    cel_usuario char(12)not null,
    id_distrito int not null ,
    dir_usuario varchar(100) not null,
    dni_usuario char(8) not null,
    email_usuario varchar(100) not null,
    password_usuario char(8) not null,
    imagen_usuario varbinary(max) , /*REVISAR VARBINARY(MAX)*/
    fechaReg_usuario DateTime not null,
    fechaAct_usuario DateTime ,
    estado_usuario varchar(100) not null,
	
    foreign key (id_tipo_usuario) references tb_tipo_usuario(id_tipo_usuario),
    foreign key (id_distrito) references tb_distrito(id_distrito)
)
go

create table tb_colaborador(
	id_colaborador int identity(1,1) not null primary key,
    id_tipo_colaborador int not null,
    nom_colaborador varchar(100) not null,
    ape_colaborador varchar(100) not null,
    dni_colaborador char(8) not null,
    imagen_colaborador varbinary(max),
    fechaReg_colaborador DateTime not null,
    fechaAct_colaborador DateTime not null,
    estado_colaborador varchar(100) not null,
    
    foreign key (id_tipo_colaborador) references tb_tipo_colaborador (id_tipo_colaborador)
    
)
go

create table tb_direntrega_usuario(
	id_usuario int not null ,
    id_direntrega int identity(1,1) not null,
    id_distrito int not null,
    des_direntrega varchar(100) not null,
    fechareg_direntrega datetime not null,
    estado_direntrega varchar(100) not null,
    
    primary key (id_direntrega, id_usuario),
    foreign key (id_usuario) references tb_usuario (id_usuario),
    foreign key (id_distrito) references tb_distrito(id_distrito)
)
go

create table tb_tarjeta(
	id_usuario int not null ,
	id_tarjeta int identity(1,1) not null,
	numero_tarjeta varchar(16) not null,
	cvv_tarjeta varchar(3) not null,
	fecha_tarjeta datetime not null,
	nombre_tarjeta varchar(100) not null,
	fechareg_direntrega datetime not null,
	estado_direntrega varchar(100) not null,
	
	primary key (id_tarjeta, id_usuario),
	foreign key (id_usuario) references tb_usuario (id_usuario)
)
go

/**/
create table tb_pedido(
	id_pedido int identity(1,1) not null primary key,
    id_usuario_cliente int not null,
    id_direntrega int not null,
    id_colaborador_repartidor int not null,
    id_tiempoentrega_pedido time not null,
    fechareg_pedido datetime not null,
    fechaact_pedido datetime not null,
    estado_pedido varchar (100) not null,
    
    foreign key (id_usuario_cliente) references tb_usuario (id_usuario),
    foreign key (id_colaborador_repartidor) references tb_colaborador (id_colaborador),
	foreign key (id_direntrega,id_usuario_cliente) references tb_direntrega_usuario (id_direntrega,id_usuario)
)
go

create table tb_producto (
	id_producto int identity(1,1) not null primary key,
    id_categoria_producto int not null,
    nom_producto varchar(100) not null,
    des_producto varchar(500),
    preciouni_producto decimal not null,
    stock_producto int not null,
    imagen_producto varbinary(max),
    estado_producto varchar(100) not null,
    
    foreign key (id_categoria_producto) references tb_categoria_producto (id_categoria_producto)
)
go

/**/
create table  tb_producto_pedido  (
	id_pedido int not null,
    id_producto_pedido int not null identity(1,1),
    id_producto  int not null,
    
    primary key(id_producto_pedido, id_pedido),
    foreign key (id_pedido) references tb_pedido (id_pedido),
    foreign key (id_producto) references tb_producto (id_producto)
)
go

create table tb_seguimiento_pedido(
	id_pedido int not null,
    id_seguimiento_pedido int identity(1,1) not null,
    fechareg_seguimiento_pedido datetime not null,
    estado_seguimmiento_pedido varchar(100) not null,
    
    primary key (id_seguimiento_pedido,id_pedido),
    foreign key (id_pedido) references tb_pedido(id_pedido)

)
go

create table tb_compra (
	id_compra int identity(1,1) not null primary key,
    id_pedido int not null unique,
    id_medio_pago int not null,
    monto_compra decimal not null,
    fechareg_compra datetime not null,
    estado_compra varchar(100) not null,
    
    foreign key (id_pedido) references tb_pedido(id_pedido),
    foreign key (id_medio_pago) references tb_mediopago(id_medio_pago)

)
go

create table tb_comentario (
	id_comentario int identity(1,1) not null primary key,
    id_usuario_cliente int not null,
    des_comentario varchar(500) not null,
    cantestrella_comentario int not null,
    fechareg_comentario datetime not null,
    estado_comentario varchar(100) not null,
    
    foreign key (id_usuario_cliente) references tb_usuario (id_usuario)
)
go

