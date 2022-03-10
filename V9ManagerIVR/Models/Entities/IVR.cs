﻿using System;
using System.Collections.Generic;
using V9Common;

namespace V9ManagerIVR.Models.Entities
{
    public class IVR : DefaultEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CompanyId { get; set; }
        public virtual Action Action { get; set; }

        public virtual List<CalendarIVR> CalendarIVRs { get; set; }

    }

    public class Action
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? IVRId { get; set; }
        public virtual IVR IVR { get; set; }
        public ActionType ActionType { get; set; }
        /// <summary>
        /// Nếu là phím bấm hay không là phím bấm
        /// </summary>
        public ActionCode ActionCode { get; set; }
        /// <summary>
        /// Action con trực thuộc action, không phải phím bấm
        /// </summary>
        public ActionCode2_ActionType SubActionCode { get; set; }
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Trong list action này chứa tất cả các loại phím bấm hay gì đó
        /// </summary>
        public virtual Action Parent { get; set; }
        public virtual ICollection<Action> Childrens { get; set; }
        /// <summary>
        /// Phím bấm
        /// </summary>
        public string Numpad { get; set; }

        #region Phần giành cho các thuộc tiếng riêng của action

        #region 1. IVR 
        /// <summary>
        /// File thông báo
        /// </summary>
        public string IVR_FileThongBao { get; set; }
        /// <summary>
        /// Số lần phát thông báo
        /// </summary>
        public int IVR_SoLanPhatThongBao { get; set; }
        /// <summary>
        /// Thời gian chờ mỗi lần phát hết thông báo, đơn vị giây
        /// </summary>
        public int IVR_ThoiGianCho { get; set; }
        public string IVR_FileThongBaoKhiBamSaiPhim { get; set; }
        public int IVR_SoLanToiDaBamSaiPhim { get; set; }

        #endregion

        #region 2. Chuyển cuộc gọi tới nhóm
        /// <summary>
        /// File thông báo
        /// </summary>
        public string TG_FileThongBao { get; set; }

        #region - Chuyển cuộc gọi tới nhóm
        /// <summary>
        /// True = nhóm, False = số nội bộ
        /// </summary>
        public bool TG_IsGroup { get; set; }
        /// <summary>
        /// Tên nhóm hoặc số nội bộ
        /// </summary>
        public string TG_GroupName { get; set; }

        #endregion

        /// <summary>
        /// khi chuyển sẽ phát nhạc chờ này
        /// </summary>
        public string TG_FileNhacCho { get; set; }
        /// <summary>
        /// Không ai nghe máy sẽ phát bận
        /// </summary>
        public string TG_FileThongBaoBan { get; set; }

        /// <summary>
        /// Nghe nhạc chờ trong khoảng thời gian(giây) sẽ thông báo bận
        /// </summary>
        public int TG_PhatThongBaoBanSau { get; set; }
        /// <summary>
        /// Số lần phát lại, phát lại là cả nhạc chờ và thông báo bận
        /// </summary>
        public int TG_SoLanPhatThongBaoBan { get; set; }

        #endregion

        #region 3. Chuyển cuộc gọi ra di động
        /// <summary>
        /// File thông báo
        /// </summary>
        public string TM_FileThongBao { get; set; }
        /// <summary>
        /// Danh sách số điện thoại đổ ra ngoài theo độ ưu tiên
        /// </summary>
        public virtual ICollection<TM_Mobile> TM_Mobiles { get; set; }
        /// <summary>
        /// khi chuyển sẽ phát nhạc chờ này
        /// </summary>
        public string TM_FileNhacCho { get; set; }
        /// <summary>
        /// Không ai nghe máy sẽ phát bận
        /// </summary>
        public string TM_FileThongBaoBan { get; set; }
        /// <summary>
        /// Nghe nhạc chờ trong khoảng thời gian(giây) sẽ thông báo bận
        /// </summary>
        public int TM_PhatThongBaoBanSau { get; set; }
        /// <summary>
        /// Số lần phát lại, phát lại là cả nhạc chờ và thông báo bận
        /// </summary>
        public int TM_SoLanPhatThongBaoBan { get; set; }

        #endregion

        #region 4. VoiceMail

        /// <summary>
        /// File thông báo
        /// </summary>
        public string VM_FileThongBao { get; set; }
        /// <summary>
        /// Tên hộp thư
        /// </summary>
        public string VM_Mail { get; set; }
        /// <summary>
        /// Mã pin
        /// </summary>
        public string VM_Pin { get; set; }
        /// <summary>
        /// Mail nhận thông báo voice mail
        /// </summary>
        public string VM_MailThongBao { get; set; }

        #endregion

        #region 5. Trả lời tự động

        #endregion

        #region 6. Kết thúc cuộc gọi

        /// <summary>
        /// File thông báo
        /// </summary>
        public string ED_FileThongBao { get; set; }
        #endregion

        #endregion
    }

    public class TM_Mobile
    {
        public Guid Id { get; set; }
        public int DoUuTien { get; set; }
        public string Phone { get; set; }
        public Guid ActionId { get; set; }
        public virtual Action Action { get; set; }
    }
}