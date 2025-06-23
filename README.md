# SimpleMedia 企業內部交流平台專案

這是一個模擬企業內部交流的平台，使用者可發文與留言，並提供基本帳號管理與個人頁面維護。專案採用 MVC 架構與登入驗證流程，強化資料保護與使用者體驗。

## 技術架構與特色
- ASP.NET Core MVC 架構，清楚劃分控制器與視圖
- Service + DTO 分層設計以便專案維護
- Cookie 驗證，結合 Claims 管理使用者狀態
- Bootstrap 實作響應式前端
- 使用 AJAX 留言功能提升互動體驗

## 使用技術

| 類別 | 技術 |
|------|------|
| 前端 | Razor View + Bootstrap + AJAX |
| 後端 | ASP.NET Core MVC (.NET 8) |
| 驗證 | Cookie 驗證、ClaimsPrincipal |
| 資料庫 | Entity Framework Core + SQL Server |
| 雜湊加密 | SHA256 + Salt |

## 預覽畫面 ![首頁](https://github.com/user-attachments/assets/50c5fd6f-760d-4f57-8ce6-50cbf498e5a7)![Detail](https://github.com/user-attachments/assets/994fbaf1-ca9c-4e0c-ba4c-497c84146455)



## 執行方式
1. 建立資料表 - 於 SQL Server 執行專案資料夾內 DB/schema.sql 檔案
2. 修改 appsettings 連線字串

## 使用者功能
- 註冊 / 登入 / 登出
- 發布貼文
- 留言、刪除、編輯留言
- 編輯個人資料

## 預計新增功能
- 角色權限管理：區分一般員工與管理者權限，管理者可檢視/刪除所有貼文
- 貼文與使用者搜尋：支援依標題、內容或發文者搜尋，方便內部文件或討論查找
- 按讚與收藏：員工可對貼文按讚或加入追蹤清單，利於蒐集與任務追蹤
- 圖片、附件上傳支援：發文支援附加圖片
- 通知功能：貼文被回覆或被按讚時發送提示
