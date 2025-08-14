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

resource "aws_instance" "sam_instance" {
count        = var.instance_count
  ami           = var.ami_id  # Replace with your AMI ID
  instance_type = var.instance_type # Replace with your instance type
  key_name      = var.key_name
  subnet_id     = var.subnet_id
  security_groups = var.security_group_id
   associate_public_ip_address = true
   user_data = <<-EOF
     #!/bin/sh
              sudo apt update -y
              sudo apt install -y nginx
              sudo systemctl enable nginx
              sudo systemctl start nginx
     EOF

  tags = {
    Name = "sam-nginx-instance-${count.index + var.name_offset+ 1}"
  }
}
  
  
