terraform {
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 6.0"
    }
  }
}

# Configure the AWS Provider
provider "aws" {
  region = "ap-south-1"
}
#configuring the network module 

module "network" {
  source      = "./modules/network"
  name_prefix = "sam-subnet"

}

module "security" {
  source = "./modules/security"
  vpc_id = module.network.vpc_id #module.network.<output_name>

}
# module "key" {
#   source = "./modules/key"

# }
module "ami" {
  source = "./modules/ami"
}

module "instances" {
  source            = "./modules/instances"
  ami_id            = module.ami.ami_id
  instance_type     = "t3.micro"                      # Replace with your desired instance type
  key_name          = "sam-key-pair"                  # Replace with your key pair name
  security_group_id = [module.security.sam_sec_group] # Replace with your security group ID
  instance_count    = 1
  subnet_id         = module.network.subnet_id # Replace with your subnet ID
  name_offset       = 0                        # Offset for naming instances
}

