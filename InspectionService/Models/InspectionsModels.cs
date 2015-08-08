using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InspectionService.Models
{
    public class InspectionCustomerModel
    {
        string inspectionCustomerId;
        [Key]
        public string InspectionCustomerId
        {
            get { return inspectionCustomerId; }
            set { inspectionCustomerId = value; }
        }
        string inspectionId;
        public string InspectionId
        {
            get { return inspectionId; }
            set { inspectionId = value; }
        }
        string userId;
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        string isAccepted;
        public string IsAccepted
        {
            get { return isAccepted; }
            set { isAccepted = value; }
        }
    }
    public class InspectionDataBaseModel
    {
        string inspectionId;
        [Key]
        public string InspectionId
        {
          get { return inspectionId; }
          set { inspectionId = value; }
        }
        string userId;
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        string vehicleId;
        public string VehicleId
        {
            get { return vehicleId; }
            set { vehicleId = value; }
        }
        string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        string level;
        public string Level
        {
            get { return level; }
            set { level = value; }
        }
        string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        string recommendedAction;
        public string RecommendedAction
        {
            get { return recommendedAction; }
            set { recommendedAction = value; }
        }
        string technicianAdvice;
        public string TechnicianAdvice
        {
            get { return technicianAdvice; }
            set { technicianAdvice = value; }
        }
        string photoList;
        public string PhotoList
        {
            get { return photoList; }
            set { photoList = value; }
        }
        string partsList;
        public string PartsList
        {
            get { return partsList; }
            set { partsList = value; }
        }
        string priceList;
        public string PriceList
        {
            get { return priceList; }
            set { priceList = value; }
        }
        string customFields;
        public string CustomFields
        {
            get { return customFields; }
            set { customFields = value; }
        }
        string isAccepted;
        public string IsAccepted
        {
            get { return isAccepted; }
            set { isAccepted = value; }
        }
        string totalCost;
        public string TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }
    }
}