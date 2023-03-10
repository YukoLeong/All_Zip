<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testdrop.aspx.cs" Inherits="testdrop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文件上傳</title>
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css" />
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
    <style type="text/css">
        #dropbox {
            border: 3px dashed #bbb;
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            border-radius: 10px;
            font-size: 18px;
            color: #bbb;
            padding: 30px;
            text-align: center;
            height: 250px;
        }

            #dropbox .fa {
                font-size: 50px;
                color: #999;
                margin-bottom: 15px;
            }

            #dropbox .text {
                font-size: 18px;
                color: #999;
            }

            #dropbox.hover {
                border-color: #000;
                color: #000;
            }

                #dropbox.hover .fa {
                    color: #000;
                }

                #dropbox.hover .text {
                    color: #000;
                }
    </style>

    <%--<link href="testdropcss/popup2.css" rel="stylesheet" />--%>
    <link href="testdropcss/popup3.css" rel="stylesheet" />

    <script src="http://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>


    <script type="text/javascript">
        $(document).ready(function () {
            $("#dropbox").on('dragenter', function (e) {
                e.stopPropagation();
                e.preventDefault();
                $(this).addClass('hover');
            });
            $("#dropbox").on('dragover', function (e) {
                e.stopPropagation();
                e.preventDefault();
            });
            $("#dropbox").on('drop', function (e) {
                e.preventDefault();
                $(this).removeClass('hover');
                var files = e.originalEvent.dataTransfer.files;
                handleFileUpload(files);
            });
            $("#dropbox").on('dragleave', function (e) {
                e.stopPropagation();
                e.preventDefault();
                $(this).removeClass('hover');
            });
        });


        function handleFileUpload(files) {
            for (var i = 0; i < files.length; i++) {
                var fd = new FormData();
                fd.append('file', files[i]);

                $.ajax({
                    url: 'testdrop.ashx',
                    type: 'POST',
                    data: fd,
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        //alert(data);
                        alert('上傳成功');

                        // 想運行css1,css2,css3的popup的話
                        //$('#successModal').modal('show');

                        // showfilename1的textbox顯示上傳檔案的名稱
                        //$('#showfilename1').val(data);

                        // showfilename1的textbox顯示上傳檔案的名稱, showfilename2的textbox顯示上傳檔案的大小
                        console.log(data);
                        var fileData = data.split("|");                       // 使用 | 分隔符将文件名和文件大小拆分
                        $('#showfilename1').val(fileData[0]);
                        $('#showfilename2').val(fileData[1]);
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        alert('上傳失敗: ' + textStatus);
                    }
                });
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div id="dropbox">
                        <i class="fa fa-cloud-upload"></i>
                        <div class="text">拖放文件到此處上傳</div>
                    </div>
                </div>
            </div>
        </div>

        <asp:TextBox ID="showfilename1" runat="server"></asp:TextBox>
        <asp:TextBox ID="showfilename2" runat="server"></asp:TextBox>

        <%--css1--%>

        <%--        <div class="modal fade" id="successModal" tabindex="-1" role="dialog" aria-labelledby="successModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="successModalLabel">上傳成功</h4>
                    </div>
                    <div class="modal-body">
                        <i class="fa fa-check-circle fa-3x text-success pull-left" style="margin-top: -10px"></i>
                        文件已成功上傳。
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">關閉</button>
                    </div>
                </div>
            </div>
        </div>--%>


        <%--css2--%>

        <%--        <div class="modal fade" id="successModal" tabindex="-1" role="dialog" aria-labelledby="successModalLabel">
            <div class="demo-preview ">
                <div class="alert alert-success alert-dismissable fade in">
                    <button type="button" data-dismiss="alert" aria-label="close" class="close"><span aria-hidden="true">×</span></button><strong>Well done!</strong> You successfully read this important alert message.
                </div>
            </div>
        </div>--%>

        <%--css3--%>


<%--        <div class="modal fade" id="successModal" tabindex="-1" role="dialog" aria-labelledby="successModalLabel">
            <div class="success-msg">
                <i class="fa fa-check"></i>
                This is a success message.
            </div>
        </div>--%>


    </form>
</body>
</html>
