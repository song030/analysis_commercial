import fitz
path = "_dummy_src/report.pdf"
doc = fitz.open(path)
for page in doc:
    text = page.get_text()
    print(text)